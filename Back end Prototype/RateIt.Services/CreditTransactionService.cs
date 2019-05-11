using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using RateIt.Services.Interfaces;
using RateIt.Repositories.Interfaces;
using RateIt.Common.Models.Enums;

namespace RateIt.Services
{
    public class CreditTransactionService : ICreditTransactionService
    {
        private readonly IRepository<CreditTransaction> _creditTransactionRepository;
        private readonly IRepository<CreditWallet> _creditWalletRepository;
        private readonly IPaymentTypeService _paymentTypesService;

        public CreditTransactionService(IRepository<CreditTransaction> creditTransactionRepository, IRepository<CreditWallet> creditWalletRepository,
            IPaymentTypeService paymentTypesService)
        {
            _creditTransactionRepository = creditTransactionRepository;
            _creditWalletRepository = creditWalletRepository;
            _paymentTypesService = paymentTypesService;
        }

        public IList<CreditTransaction> GetTopTransactionsFromUser(long userId, int amount, int page)
        {
            return _creditTransactionRepository.GetAll()
                .Where(x => x.FromUserId == userId)
                .OrderBy(x => x.Timestamp)
                .Skip(page * amount).Take(amount).ToList();
        }

        public IList<CreditTransaction> GetTopTransactionsToUser(long userId, int amount, int page)
        {
            return _creditTransactionRepository.GetAll()
                .Where(x => x.ToUserId == userId)
                .OrderBy(x => x.Timestamp)
                .Skip(page * amount).Take(amount).ToList();
        }

        public bool AddMoCreditsTransaction(long to, long fromid, double amount, TransferType type, long? linkedId)
        {
            var matchingPaymentType = _paymentTypesService.GetPaymentType(type);
            if (matchingPaymentType != null)
            {
                var creditTransaction = new CreditTransaction()
                {
                    AdminNotes = string.Empty,
                    Amount = amount,
                    FromUserId = fromid,
                    LinkedId = linkedId,
                    Notes = string.Empty,
                    Timestamp = DateTime.Now,
                    ToUserId = to,
                    PaymentTypeId = matchingPaymentType.Id
                };
                _creditTransactionRepository.Add(creditTransaction);
                return Convert.ToBoolean(_creditTransactionRepository.Save());
            }
            return false;
        }

        public IList<CreditTransaction> GetTopTransactionsForUser(long userId, int amount, int page)
        {
            return _creditTransactionRepository.GetAll()
                .Where(x => x.FromUserId == userId || x.ToUserId == userId)
                .OrderBy(x => x.Timestamp)
                .Skip(page * amount).Take(amount).ToList();
        }
    }
}
