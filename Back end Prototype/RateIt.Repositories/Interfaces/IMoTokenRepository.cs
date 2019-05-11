using RateIt.Common.Models;
using RateIt.Common.Models.Enums;
using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Interfaces
{
    public interface IMoTokenRepository
    {
        string AddContent(long articleId, long subArticleId, long contentId, string rawData);
        IList<RawPageContent> GetContentByArticle(long articleId);
        IList<RawPageContent> GetContentBySubArticle(long subArticleId);
        RawPageContent GetContentByContent(long contentId);
        string TransferFromAdminTo(string addressTo, double value);
        IList<Transaction> GetTransactionEventsInbound(string ethereumAddress, int amount, int page);
        IList<Transaction> GetTransactionEventsOutbound(string ethereumAddress, int amount, int page);
        IList<Transaction> GetTransactionEvents(string ethereumAddress, int amount, int page);
    }
}
