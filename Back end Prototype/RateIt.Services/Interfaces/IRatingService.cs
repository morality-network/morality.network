using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface IRatingService
    {
        bool AddRating(long userid, string url, double value);
        Rating GetRatingBySubDirectoryId(long subDirectoryId);
        Rating GetRatingByRatingId(long ratingId);
        bool HasUserRated(long userid, string url);
        bool UpdateRating(long ratingId, double value);
    }
}
