using Bank;
using Nethereum.Contracts;
using RateIt.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MoBank.Interfaces
{
    public interface IMoralityStorageBank
    {
        Task<string> AddModerator(string address);
        Task<string> RemoveModerator(string address);
        Task<bool> DoesModeratorExist(string address);
        Task<string> AddContentViaEvent(long articleId, long subArticleId, long contentId,
            string rawData);
        Task<List<EventLog<ContentEventDTO>>> GetAddContentEvents();
        Task<IList<RawPageContent>> GetContentByArticleEvent(long articleId);
        Task<IList<RawPageContent>> GetContentBySubArticleEvent(long subArticleId);
        Task<RawPageContent> GetExactContentEvent(long contentId);
        Task<string> AddContent(long articleId, long subArticleId, long contentId, string rawData);
        Task<RawPageContent> GetContentById(long contentId);
        Task<List<BigInteger>> GetAllContentIds();
        Task<List<BigInteger>> GetAllContentIdsForSubArticle(long subArticleId);
        Task<List<BigInteger>> GetAllContentIdsForArticle(long articleId);
        Task<BigInteger> CountAllContentForSubArticle(long subArticleId);
        Task<BigInteger> CountAllContentForArticle(long articleId);
        Task<IList<RawPageContent>> GetContentBySubArticleId(long subArticleId, int page);
        Task<IList<RawPageContent>> GetContentByArticleId(long articleId, int page);
    }
}
