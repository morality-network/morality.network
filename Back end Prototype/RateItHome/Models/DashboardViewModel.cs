using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateItHome.Models
{
    public class DashboardViewModel
    {
        public IList<Notification> Notifications { get; set; }
        public IList<Notification> Activities { get; set; }
        public IList<Transaction> Transactions { get; set; }
        public double AvgScore { get; set; }
        public IList<double> EarnedDataset { get; set; }
        public IList<string> ChatHistory { get; set; }
    }
}