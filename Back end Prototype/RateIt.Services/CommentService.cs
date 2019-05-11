using RateIt.Common.Models.Enums;
using RateIt.Model;
using RateIt.Repositories.Interfaces;
using RateIt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> _commentRepository;
        private readonly IUserService _userService;
        private readonly IReportService _reportService;
        private readonly IUpvoteService _upvoteService;
        private readonly IContentService _contentService;
        private readonly ISubDirectoryService _subDirectoryService;
        private readonly INotificationService _notificationService;
        private readonly IActivityService _activityService;
        private readonly ICreditWalletService _creditWalletService;

        public CommentService(IRepository<Comment> commentRepository, IUserService userService, IReportService reportService,
            IUpvoteService upvoteService, IContentService contentService, ISubDirectoryService subDirectoryService,
            INotificationService notificationService, IActivityService activityService, ICreditWalletService creditWalletService)
        {
            _commentRepository = commentRepository;
            _userService = userService;
            _reportService = reportService;
            _activityService = activityService;
            _upvoteService = upvoteService;
            _contentService = contentService;
            _notificationService = notificationService;
            _subDirectoryService = subDirectoryService;
            _creditWalletService = creditWalletService;
        }

        public IEnumerable<Comment> GetCommentsByParentId(long parentId)
        {
            return _commentRepository.GetAll()
                .Where(x => x.ParentId == parentId);
        }

        public Comment AddComment(string url, string content, long creatorId, long? parentId)
        {
            var creator = _userService.GetUserById(creatorId);
            if (creator != null) {
                //Get all the info needed for the insertion
                var subDirectory = _subDirectoryService.FindOrInsertSite(url);
                var contentObj = _contentService.AddContent(subDirectory.Id, ContentTypeMap.Comment);
                var parentComment = (Comment)null;
                if (parentId.HasValue)
                    parentComment = GetCommentById(parentId.Value);
                //Add the comment
                var comment = new Comment()
                {
                    Upvotes = 0,
                    Sitename = subDirectory.Site?.Name,
                    Content = content,
                    CreatedAt = DateTime.Now,
                    ContentId = contentObj.Id,
                    CreatorId = creatorId,
                    CreatedByAdmin = false,
                    ModifiedAt = DateTime.Now,
                    ParentId = parentComment != null ? parentId : null,
                    ProfilePictureUrl = creator.ProfilePictureUrl,
                    Pings = 0
                };
                _commentRepository.Add(comment);
                var saved = Convert.ToBoolean(_commentRepository.Save());
                if (saved) return comment;
            }
            return null;
        }

        public void AddCommentNotificationsAndActivity(long? parentId, long contentId, long subDirectoryId, User creator)
        {
            if (parentId.HasValue)
            {
                var parentComment = GetCommentById(parentId.Value);
                _notificationService.AddNotification(NotificationTypeMap.Reply, parentComment.ContentId, parentComment.CreatorId,
                    subDirectoryId, creator.Fullname);
                _activityService.AddActivity(ActivityTypeMap.Replied, contentId, creator.Id, subDirectoryId);
            }
            else _activityService.AddActivity(ActivityTypeMap.Commented, contentId, creator.Id, subDirectoryId);
        }

        public IList<Comment> GetSubComments(long parentId, int from, int to)
        {
            return GetCommentsByParentId(parentId)
                .Skip(from)
                .Take(to)
                .ToList();
        }

        public int GetSubCommentsCount(long parentId)
        {
            return GetCommentsByParentId(parentId).Count();
        }

        public Comment GetCommentById(long id)
        {
            return _commentRepository.GetAll()
                .FirstOrDefault(x => x.Id == id);
        }

        public bool FlagComment(long userId, long commentId)
        {
            var currentUser = _userService.GetUserById(userId);
            var comment = GetCommentById(commentId);
            if (currentUser != null && comment != null)
            {
                var reported = _reportService.ReportComment(currentUser.Id, (int)comment.Id);
                if (reported)
                {
                    var newFlagCount = _reportService.GetReportClaimCountForComment(commentId);
                    comment.FlagCount = newFlagCount;
                    _commentRepository.Update(comment);
                    return Convert.ToBoolean(_commentRepository.Save());
                }
            }
            return false;
        }

        public bool RateCommentUpDown(long userId, long commentId, Direction direction)
        {
            var currentUser = _userService.GetUserById(userId);
            var comment = GetCommentById(commentId);
            if (currentUser != null && comment != null)
            {
                var hasUserVoted = _upvoteService.HasUserVotedOnComment(currentUser.Id, comment.Id);
                if (hasUserVoted)
                {
                    var success =  _upvoteService.UpdateExistingVote(currentUser.Id, commentId, direction);
                    if (success)
                    {
                        var upvoteCount = _upvoteService.GetUpVotesByCommentId(comment.Id);
                        comment.Upvotes = upvoteCount;
                        return Convert.ToBoolean(_commentRepository.Update(comment));
                    }
                }
                else
                {
                    return _upvoteService.AddUpvote(
                        comment.Id,
                        currentUser.Id,
                        direction
                    );
                }
            }
            return false;
        }

        public IEnumerable<Comment> GetCommentsBySubDirectoryId(long subDirectoryId)
        {
            return _commentRepository.GetAll()
                .Where(x => x.Content1.SubDirectoryId == subDirectoryId);
        }

        public IList<Comment> GetCommentsBySubDirectory(long subDirectoryId, int page, int perPage, string searchTerm = null)
        {
            var comments = GetCommentsBySubDirectoryId(subDirectoryId);
            if (!string.IsNullOrEmpty(searchTerm))
                comments = comments.Where(x => x.Content.ToLower().Contains(searchTerm.ToLower()));
            return comments.Skip(page * perPage)
                .Take(perPage)
                .ToList();
        }

        public void AddCommentVoteNotificationsAndActivity(long commentId, User user)
        {
            var comment = GetCommentById(commentId);
            _notificationService.AddNotification(NotificationTypeMap.Rate, comment.ContentId, comment.CreatorId, 
                comment.Content1.SubDirectoryId, user.Fullname);
            _activityService.AddActivity(ActivityTypeMap.Rated, comment.ContentId, user.Id, comment.Content1.SubDirectoryId);
        }

        public void AddCommentTipNotificationsAndActivity(long commentId, User user)
        {
            var comment = GetCommentById(commentId);
            _notificationService.AddNotification(NotificationTypeMap.Tip, comment.ContentId, comment.CreatorId,
                comment.Content1.SubDirectoryId, user.Fullname);
            _activityService.AddActivity(ActivityTypeMap.Tipped, comment.ContentId, user.Id, comment.Content1.SubDirectoryId);
        }

        public bool TipComment(long userId, long commentId, double amount)
        {
            var user = _userService.GetUserById(userId);
            var comment = GetCommentById(commentId);
            var tipped = _creditWalletService.Transfer(userId, comment.CreatorId, amount);
            if (tipped)
            {
                comment.TipAmount += amount;
                _commentRepository.Update(comment);
                return Convert.ToBoolean(_commentRepository.Save());
            }
            return false;
        }
    }
}
