using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateItWebApi.Models
{
    public class HomeViewModel
    {
        public IList<NotificationModel> Notifications { get; set; }
        public IList<CreditTransactionModel> Transactions { get; set; }
        public IList<ActivityModel> Activities { get; set; }
        public double AvgScore { get; set; }
        public IList<double> EarnedDataset { get; set; }
        public IList<string> ChatHistory { get; set; }
    }
}