using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateItHome.Models
{
    public class Notification
    {
        public string Action { get; set; }
        public string DateTimeFormatted => DateTimeAdded.ToShortDateString();
        public DateTime DateTimeAdded { get; set; }
    }
}