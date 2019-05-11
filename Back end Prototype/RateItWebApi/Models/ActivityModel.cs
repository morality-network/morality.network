using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateItWebApi.Models
{
    public class ActivityModel
    {
        public string ActionText { get; set; }
        public Action ActionType { get; set; }
        public DateTime Timestamp { get; set; }
        public string FormattedTimestamp { get; set; }
    }
}