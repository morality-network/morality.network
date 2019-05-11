using RateIt.Common.Models.Enums;
using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface ICommentService
    {
        IList<Comment> GetSubComments(long parentId, int from, int to);
        bool FlagComment(long userId ,long commentId);
        bool RateCommentUpDown(long userId, long commentId, Direction direction);
        int GetSubCommentsCount(long parentId);
        IEnumerable<Comment> GetCommentsByParentId(long parentId);
        Comment GetCommentById(long id);
        IEnumerable<Comment> GetCommentsBySubDirectoryId(long subDirectoryId);
        IList<Comment> GetCommentsBySubDirectory(long subDirectoryId, int page, int perPage, string searchTerm = null);
        Comment AddComment(string url, string content, long creatorId, long? parentId);
        void AddCommentNotificationsAndActivity(long? parentId, long contentId, long subDirectoryId, User creator);
        void AddCommentVoteNotificationsAndActivity(long commentId, User user);
        void AddCommentTipNotificationsAndActivity(long commentId, User user);
        bool TipComment(long userId, long commentId, double amount);
    }
}
