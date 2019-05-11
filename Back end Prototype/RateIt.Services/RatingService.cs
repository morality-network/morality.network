using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RateIt.Services.Interfaces;
using RateIt.Repositories.Interfaces;

namespace RateIt.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRepository<Rating> _ratingRepository;
        private readonly IUserService _userService;
        private readonly ISubDirectoryService _subDirectoryService;
        private readonly IUserRatingService _userRatingService;

        public RatingService(IRepository<Rating> ratingRepository, IUserService userService,
            ISubDirectoryService subDirectoryService, IUserRatingService userRatingService)
        {
            _ratingRepository = ratingRepository;
            _subDirectoryService = subDirectoryService;
            _userRatingService = userRatingService;
            _userService = userService;
        }

        public bool AddRating(long userid, string url, double value)
        {
            var user = _userService.GetUserById(userid);
            if (user != null) return false;
            if(!HasUserRated(userid, url)) {
                var subDirectory = _subDirectoryService.FindOrInsertSite(url);
                var rate = GetRatingBySubDirectoryId(subDirectory.Id);
                if (rate == null)
                {
                    _ratingRepository.Add(new Rating()
                    {
                        RatingValue = value,
                        SubDirectoryId = subDirectory.Id
                    });
                    _userRatingService.AddUserRating(userid, rate.Id, value);
                }
                else
                     UpdateRating(rate.Id, value);
                //set user stat
                _userService.CalculateAndUpdateUserRatingStatistics(user.Id);
                return true;
            }
            return false;
        }

        public Rating GetRatingBySubDirectoryId(long subDirectoryId)
        {
            return _ratingRepository.GetAll()
                .FirstOrDefault(x => x.SubDirectoryId == subDirectoryId);
        }

        public Rating GetRatingByRatingId(long ratingId)
        {
            return _ratingRepository.GetAll()
                .FirstOrDefault(x => x.Id == ratingId);
        }

        public bool HasUserRated(long userid, string url)
        {
            var subDirectory = _subDirectoryService.FindOrInsertSite(url);
            var rating = GetRatingBySubDirectoryId(subDirectory.Id);
            if (rating == null)
                return false;
            var userRating = _userRatingService.GetUserRating(userid, rating.Id);
            return userRating == null ? false : true;
        }

       
        public bool UpdateRating(long ratingId, double value)
        {
            var originalRating = GetRatingByRatingId(ratingId);
            if (originalRating != null)
            {
                //Calculate new value
                var ratingsCount = _userRatingService.CountTotalRated(ratingId);
                double ratings = _userRatingService.SumUserRatings(ratingId);
                var updateValue = ratings / ((double)ratingsCount);
                //Update rating
                originalRating.RatingValue = (double)updateValue;
                _ratingRepository.Update(originalRating);
                return Convert.ToBoolean(_ratingRepository.Save());
            }
            return false;
        }
    }
}
