using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Common.Models
{
    public class TransactionResult
    {
        public long Id { get; set; }
        public long FromUserId { get; set; }
        public long ToUserId { get; set; }
        public string FromUserName { get; set; }
        public string ToUserName { get; set; }
        public double Amount { get; set; }
        public DateTime Timestamp { get; set; }
        public Nullable<long> LinkedId { get; set; }
        public string PaymentType { get; set; }
    }
}
