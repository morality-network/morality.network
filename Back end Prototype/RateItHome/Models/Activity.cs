using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateItHome.Models
{
    public class Activity
    {
        public string ActionText { get; set; }
        public Action ActionType { get; set; }
        public DateTime Timestamp { get; set; }
        public string FormattedTimestamp { get; set; }

        public enum Action
        {
            Rated = 0,
            Commented = 1,
            Replied = 2,
            Reported = 3
        }
    }
}