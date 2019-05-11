using RateIt.Common.Models;
using RateIt.Common.Models.Enums;
using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface IMoTokenService
    {
        string AddContentToBlockChain(PageContent content);
        IList<RawPageContent> GetContentByArticleId(long articleId);
        IList<RawPageContent> GetContentBySubArticleId(long subArticleId);
        RawPageContent GetExactContent(long contentId);
        IList<Transaction> GetTransactonEvents(long userId, TransactionFilter filter, int amount, int page);
    }
}
