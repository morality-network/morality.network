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
    public class UpvoteService : IUpvoteService
    {
        public readonly IRepository<Upvote> _upvoteRepository;

        public UpvoteService(IRepository<Upvote> upvoteRepository)
        {
            _upvoteRepository = upvoteRepository;
        }

        public bool AddUpvote(long userId, long commentId, Direction direction)
        {
            _upvoteRepository.Add(new Upvote()
            {
                CommentId = commentId,
                UserId = userId,
                Vote = Convert.ToBoolean((int) direction)
            });
            return Convert.ToBoolean(_upvoteRepository.Save());
        }

        public Upvote GetUpvote(long userId, long commentId)
        {
            return _upvoteRepository.GetAll()
                .FirstOrDefault(x => x.UserId == userId && x.CommentId == commentId);
        }

        public bool HasUserVotedOnComment(long userId, long commentId)
        {
            var existingRecord = GetUpvote(userId, commentId);
            if (existingRecord != null) return true;
            return false;
        }

        public bool UpdateExistingVote(long userId, long commentId, Direction direction)
        {
            var existingRecord = GetUpvote(userId, commentId);
            if(existingRecord != null)
            {
                existingRecord.Vote = Convert.ToBoolean((int)direction);
                _upvoteRepository.Update(existingRecord);
                return Convert.ToBoolean(_upvoteRepository.Save());
            }
            return false;
        }

        public int GetUpVotesByCommentId(long commentId)
        {
            var ups = GetVotesByCommentId(commentId, true);
            var downs = GetVotesByCommentId(commentId, false);
            return ups - downs;
        }

        public int GetVotesByCommentId(long commentId, bool upvote)
        {
            return _upvoteRepository.GetAll()
                .Where(x => x.CommentId == commentId && x.Vote)
                .Count();
        }
    }
}
