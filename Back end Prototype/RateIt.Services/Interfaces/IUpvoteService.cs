using RateIt.Common.Models.Enums;
using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface IUpvoteService
    {
        bool HasUserVotedOnComment(long userId, long commentId);
        bool UpdateExistingVote(long userId, long commentId, Direction direction);
        bool AddUpvote(long userId, long commentId, Direction direction);
        Upvote GetUpvote(long userId, long commentId);
        int GetUpVotesByCommentId(long commentId);
        int GetVotesByCommentId(long commentId, bool upvote);
    }
}
