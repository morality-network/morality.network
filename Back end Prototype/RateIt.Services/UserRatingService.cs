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
    public class UserRatingService : IUserRatingService
    {
        private readonly IRepository<UserRating> _userRatingRepository;

        public UserRatingService(IRepository<UserRating> userRatingRepository)
        {
            _userRatingRepository = userRatingRepository;
        }

        public UserRating GetUserRating(long userId, long ratingId)
        {
            return _userRatingRepository.GetAll()
                .FirstOrDefault(x => x.UserId == userId && x.RatingId == ratingId);
        }

        public int CountTotalRated(long ratingId)
        {
            return _userRatingRepository.GetAll().Where(x => x.RatingId == ratingId)
                .Count();
        }

        public double SumUserRatings(long ratingId)
        {
            return _userRatingRepository.GetAll().Where(x => x.RatingId == ratingId)
                .Sum(x => x.Rating);
        }

        public bool AddUserRating(long userId, long RatingId, double value)
        {
            _userRatingRepository.Add(new UserRating()
            {
                UserId = userId,
                RatingId = RatingId,
                Rating = value
            });
            return Convert.ToBoolean(_userRatingRepository.Save());
        }

        public int GetAllUsersRatingsCount(long userId)
        {
            return _userRatingRepository.GetAll()
                .Where(x => x.UserId == userId)
                .Count();
        }

        public double GetUsersOverallRating(long userId)
        {
            return _userRatingRepository.GetAll()
                .Where(x => x.UserId == userId)
                .Sum(x => x.Rating) / GetAllUsersRatingsCount(userId);
        }
    }
}
