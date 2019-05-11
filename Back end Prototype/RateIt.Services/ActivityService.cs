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
    public class ActivityService : IActivityService
    {
        private readonly IRepository<RateIt.Model.Activity> _activityRepository;
        private readonly IRepository<ActivityType> _activityTypeRepository;

        public ActivityService(IRepository<Activity> activityRepository, IRepository<ActivityType> activityTypeRepository)
        {
            _activityRepository = activityRepository;
            _activityTypeRepository = activityTypeRepository;
        }

        public bool AddActivity(ActivityTypeMap activityType, long contentId, long userId, long subDirectoryId)
        {
            var activityTypeObj = GetActivityTypeFromEnum(activityType);
            if (activityTypeObj != null)
            {
                var activity = new Activity()
                {
                    ContentId = contentId,
                    ActivityTypeId = activityTypeObj.Id,
                    Timestamp = DateTime.Now,
                    SubDirectoryId = subDirectoryId
                };
                AddActivityMessageText(activity, activityType);
                _activityRepository.Add(activity);
                return Convert.ToBoolean(_activityRepository.Save());
            }
            return false;
        }

        public void AddActivityMessageText(Activity activity, ActivityTypeMap activityType)
        {
            var message = string.Empty;
            switch (activityType)
            {
                case ActivityTypeMap.Commented:
                    message = $"You added a comment at {activity.Timestamp}";
                    break;
                case ActivityTypeMap.Liked:
                    message = $"You liked a comment at {activity.Timestamp}";
                    break;
                case ActivityTypeMap.Mentioned:
                    message = $"You mentioned someone in a comment at {activity.Timestamp}";
                    break;
                case ActivityTypeMap.Rated:
                    message = $"You rated a website at {activity.Timestamp}";
                    break;
                case ActivityTypeMap.Replied:
                    message = $"You replied to a comment at {activity.Timestamp}";
                    break;
                case ActivityTypeMap.Reported:
                    message = $"You reported a comment at {activity.Timestamp}";
                    break;
                case ActivityTypeMap.Tipped:
                    message = $"You tipped somebody at {activity.Timestamp}";
                    break;
                case ActivityTypeMap.AnsweredPoll:
                    message = $"You answered a poll at {activity.Timestamp}";
                    break;
                case ActivityTypeMap.AnsweredSurvey:
                    message = $"You answered a survey at {activity.Timestamp}";
                    break;
                case ActivityTypeMap.GaveToCrowdfund:
                    message = $"You gave to a crowdfund at {activity.Timestamp}";
                    break;
                case ActivityTypeMap.ValidatedContent:
                    message = $"You tried to validate content at {activity.Timestamp}";
                    break;
            }
            activity.ActivityText = message;
        }

        public ActivityType GetActivityTypeFromEnum(ActivityTypeMap activityType)
        {
            return _activityTypeRepository.GetAll()
                   .FirstOrDefault(x => x.TypeName == activityType.ToString());
        }

        public IList<Activity> GetActivity(long userid, int perPage, int page)
        {
            return _activityRepository.GetAll().Where(x => x.UserId == userid)
                .OrderByDescending(x => x.Timestamp)
                .Skip(page*perPage)
                .Take(perPage)
                .ToList();
        }
    }
}
