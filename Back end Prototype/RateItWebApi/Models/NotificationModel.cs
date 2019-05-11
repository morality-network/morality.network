using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateItWebApi.Models
{
    public class NotificationModel
    {
        public string Action { get; set; }
        public string DateTimeFormatted { get; set; }
        public DateTime DateTimeAdded { get; set; }
    }
}