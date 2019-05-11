using RateIt.Common.Models.Enums;
using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface ICreditTransactionService
    {
        IList<CreditTransaction> GetTopTransactionsFromUser(long userId, int amount, int page);
        IList<CreditTransaction> GetTopTransactionsToUser(long userId, int amount, int page);
        IList<CreditTransaction> GetTopTransactionsForUser(long userId, int amount, int page);
        bool AddMoCreditsTransaction(long to, long fromid, double amount, TransferType type, long? linkedId);
    }
}
