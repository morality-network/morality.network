using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface IUserRatingService
    {
        UserRating GetUserRating(long userId, long ratingId);
        int CountTotalRated(long ratingId);
        double SumUserRatings(long ratingId);
        bool AddUserRating(long userId, long ratingId, double value);
        int GetAllUsersRatingsCount(long userId);
        double GetUsersOverallRating(long userId);
    }
}
