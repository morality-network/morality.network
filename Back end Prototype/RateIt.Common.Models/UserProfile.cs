using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Common.Models
{
    public class UserProfile
    {
        public long Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string ProfilePictureUrl { get; set; }
        public System.DateTime LastLogin { get; set; }
        public bool Active { get; set; }
        public string Bio { get; set; }
        public string Comments { get; set; }
        public string CurrentApp { get; set; }
        public double OverallRating { get; set; }
        public double OverallReportCount { get; set; }
        public double OverallRatingCount { get; set; }
        public double OverallCommentCount { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime LastActiveAt { get; set; }
        public IList<Activity> UserActivities { get; set; }
        public IList<Notification> UserNotifications { get; set; }
        public IList<UserMessage> UserMessages { get; set; }
    }
}
