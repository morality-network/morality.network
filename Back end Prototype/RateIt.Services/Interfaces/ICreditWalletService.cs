using RateIt.Common.Models.Enums;
using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface ICreditWalletService
    {
        CreditWallet GetCreditWalletByUserId(long userId);
        bool Transfer(long from, long to, double amount);
        bool Transfer(long from, long to, double amount, TransferType type);
        bool UpdateWallet(CreditWallet wallet);
        bool PayIntoWallets(IList<User> users, double amountToPay);
    }
}
