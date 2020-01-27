using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RateIt.Services.Interfaces;
using RateIt.Model;
using RateIt.Repositories.Interfaces;
using RateIt.Common.Models.Enums;
using RateIt.Repositories.Repositories;

namespace RateIt.Services
{
    public class ReportService : IReportService
    {
        private readonly IRepository<ReportClaim> _reportClaimRepository;
        private readonly IInvestigationService _investigationService;
        private readonly IUserService _userService;
        private readonly INotificationService _notificationService;
        private readonly IContentService _contentService;
        private readonly IRepository<Comment> _commentRepository;

        public ReportService(IRepository<ReportClaim> reportClaimRepository, IInvestigationService investigationService,
            IUserService userService, INotificationService notificationService, IContentService contentService,
            IRepository<Comment> commentRepository)
        {
            _reportClaimRepository = reportClaimRepository;
            _investigationService = investigationService;
            _userService = userService;
            _notificationService = notificationService;
            _contentService = contentService;
            _commentRepository = commentRepository;
        }

        public bool ReportComment(long userId, int commentId)
        {
            var user = _userService.GetUserById(userId);
            if (user != null && HasUserAlreadyReported(userId, commentId))
            {
                var comment = _commentRepository.GetAll().FirstOrDefault(x => x.Id == commentId);
                if (comment != null)
                {
                    var content = comment.Content1;
                    if (content != null)
                    {
                        var reported = AddReportClaim(userId, commentId);
                        if (reported)
                        {
                            if (!_investigationService.DoesInvestigationExistForComment(commentId))
                                _investigationService.AddInvestigation(userId, commentId);

                            AddReportClaim(userId, commentId);
                            _userService.CalculateAndUpdateUserReportStatistics(userId);
                            _notificationService.AddNotification(NotificationTypeMap.Report, content.Id, comment.CreatorId,
                                content.SubDirectoryId, user.Fullname);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool AddReportClaim(long userId, int commentId)
        {
            _reportClaimRepository.Add(new ReportClaim()
            {
                ByUser = userId,
                CommentId = commentId
            });
            return Convert.ToBoolean(_reportClaimRepository.Save());
        }

        public bool HasUserAlreadyReported(long userId, long commentId)
        {
            var reportClaim = _reportClaimRepository.GetAll()
                .FirstOrDefault(x => x.ByUser == userId && x.CommentId == commentId);
            if (reportClaim != null) return true;
            return false;
        }

        public int GetReportClaimCountForComment(long commentId)
        {
            return _reportClaimRepository.GetAll()
                .Where(x => x.CommentId == commentId)
                .Count();
        }
    }
}
