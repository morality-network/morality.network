using Bank;
using MoBank.Interfaces;
using RateIt.Common.Models;
using RateIt.Model;
using RateIt.Repositories.Interfaces;
using RateIt.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class MoTokenRepository : IMoTokenRepository
    {
        public IMoralityTokenBank _moralityTokenBank;

        public MoTokenRepository(IMoralityTokenBank moralityTokenBank)
        {
            _moralityTokenBank = moralityTokenBank;
        }

        public MoTokenRepository(MoralityTokenSettings settings)
        {
            _moralityTokenBank = MoralityTokenBankFactory.GetMoralityTokenBank(settings);
        }

        public string AddContent(long articleId, long subArticleId, long contentId, string rawData)
        {
            return AsyncHelper.RunSync(() => _moralityTokenBank.AddContentViaEvent(articleId, subArticleId, contentId, rawData));
        }

        public IList<RawPageContent> GetContentByArticle(long articleId)
        {
            return AsyncHelper.RunSync(() => _moralityTokenBank.GetContentByArticleEvent(articleId));
        }

        public IList<RawPageContent> GetContentBySubArticle(long subArticleId)
        {
            return AsyncHelper.RunSync(() => _moralityTokenBank.GetContentBySubArticleEvent(subArticleId));
        }

        public RawPageContent GetContentByContent(long contentId)
        {
            return AsyncHelper.RunSync(() => _moralityTokenBank.GetExactContentEvent(contentId));
        }

        public string TransferFromAdminTo(string addressTo, double value)
        {
            return AsyncHelper.RunSync(() => _moralityTokenBank.Transfer(addressTo, value))?.TransactionHash ?? string.Empty;
        }

        public IList<Transaction> GetTransactionEventsInbound(string ethereumAddress, int amount, int page)
        {
            return AsyncHelper.RunSync(() =>
                _moralityTokenBank.GetTransactionEventsInbound(ethereumAddress, amount, page)
            ).Select(x => new Transaction()
            {
                AddressFrom = x.Event.From,
                AddressTo = x.Event.To,
                Amount = (double)_moralityTokenBank.ConvertToDecimal(x.Event.Value),
                Confirmed = true,
                BlockNumber = (long)x.Log.BlockNumber.Value,
                TransactionHash = x.Log.TransactionHash
            }).ToList();
        }

        public IList<Transaction> GetTransactionEventsOutbound(string ethereumAddress, int amount, int page)
        {
            return AsyncHelper.RunSync(() => 
                _moralityTokenBank.GetTransactionEventsInbound(ethereumAddress, amount, page)
            ).Select(x => new Transaction()
            {
                AddressFrom = x.Event.From,
                AddressTo = x.Event.To,
                Amount = (double)_moralityTokenBank.ConvertToDecimal(x.Event.Value),
                Confirmed = true,
                BlockNumber = (long)x.Log.BlockNumber.Value,
                TransactionHash = x.Log.TransactionHash
            }).ToList();
        }

        public IList<Transaction> GetTransactionEvents(string ethereumAddress, int amount, int page)
        {
            return AsyncHelper.RunSync(() => 
                _moralityTokenBank.GetTransactionEvents(ethereumAddress, amount, page)
            ).Select(x => new Transaction()
            {
                AddressFrom = x.Event.From,
                AddressTo = x.Event.To,
                Amount = (double)_moralityTokenBank.ConvertToDecimal(x.Event.Value),
                Confirmed = true,
                BlockNumber = (long)x.Log.BlockNumber.Value,
                TransactionHash = x.Log.TransactionHash
            }).ToList();
        }
    }
}
