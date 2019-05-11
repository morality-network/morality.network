using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateItHome.Models
{
    public class Transaction
    {
        public Action ActionType { get;set; }
        public double Amount { get; set; }
        public String FormattedTimestamp => Timestamp.ToShortDateString();
        public DateTime Timestamp { get; set; }
        public enum Action
        {
            Incoming = 0,
            Outgoing = 1
        }
    }
}