using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface IUserService
    {
        int GetAllUsersCount(RateIt.Utilities.TimeSpan lastActiveSince);
        IList<User> GetRandomUsers(int sampleSize, DateTime startDate);
        User GetUserByEmail(string email);
        User GetUserById(long userId);
        bool CalculateAndUpdateUserRatingStatistics(long userId);
        bool HasAlreadyRegistered(string email);
        bool UpdateUserInfo(long userId, string bio, string fullname, string profilePicUrl);
        bool UpdateAppKey(string aspUserId, string newKey);
        bool AddUser(string email, string name, string aspUserId, string currentApp);
        User GetUserByAspUserId(string aspUserId);
        bool CalculateAndUpdateUserReportStatistics(long userId);
        bool DeactivateUser(long userId);
    }
}
