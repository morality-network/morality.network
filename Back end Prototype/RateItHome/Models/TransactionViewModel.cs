using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RateIt.Model;
namespace RateItHome.Models
{
    public class TransactionViewModel
    {
        public RateIt.Model.Transaction TransactionToMake { get; set; }
        public CreditTransaction CreditTransactionToMake { get; set; }
        public IList<RateIt.Model.Transaction> Transactions { get; set; }
        public IList<CreditTransaction> CreditTransactions { get; set; }
        public CreditWallet CreditWallet { get; set; }
        public bool Save {get;set;}

        public TransactionViewModel() { }
    }
}