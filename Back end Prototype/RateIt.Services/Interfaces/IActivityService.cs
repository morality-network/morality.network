using RateIt.Common.Models.Enums;
using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface IActivityService
    {
        bool AddActivity(ActivityTypeMap activityType, long contentId, long userId, long subDirectoryId);
        void AddActivityMessageText(Activity activity, ActivityTypeMap activityType);
        ActivityType GetActivityTypeFromEnum(ActivityTypeMap activityType);
        IList<Activity> GetActivity(long userid, int perPage, int page);
    }
}
