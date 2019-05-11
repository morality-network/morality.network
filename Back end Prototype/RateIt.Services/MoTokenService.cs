using RateIt.Common.Models;
using RateIt.Common.Models.Enums;
using RateIt.Model;
using RateIt.Repositories.Interfaces;
using RateIt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace RateIt.Services
{
    public class MoTokenService : IMoTokenService
    {
        private readonly IMoTokenRepository _moTokenRepository;
        private readonly IContentTypeService _contentTypeService;
        private readonly IAccountService _accountService;

        public MoTokenService(IMoTokenRepository moTokenRepository, IContentTypeService contentTypeService,
            IAccountService accountService)
        {
            _moTokenRepository = moTokenRepository;
            _contentTypeService = contentTypeService;
            _accountService = accountService;
        }

        public string AddContentToBlockChain(PageContent content)
        {
            if (content != null)
            {
                var rawContent = SerializeContent(content);
                return _moTokenRepository.AddContent(content.SiteId, content.SubDirectoryId, content.ContentId, rawContent);
            }
            return null;
        }

        public string SerializeContent(PageContent content)
        {
            if (content != null)
            {
                var serializer = new JavaScriptSerializer();
                return serializer.Serialize(content);
            }
            throw new Exception("Content is null exception");
        }

        public IList<RawPageContent> GetContentByArticleId(long articleId)
        {
            return _moTokenRepository.GetContentByArticle(articleId);
        }

        public IList<RawPageContent> GetContentBySubArticleId(long subArticleId)
        {
            return _moTokenRepository.GetContentByArticle(subArticleId);
        }

        public RawPageContent GetExactContent(long contentId)
        {
            return _moTokenRepository.GetContentByContent(contentId);
        }

        public IList<Transaction> GetTransactonEvents(long userId, TransactionFilter filter, int amount, int page)
        {
            var userAccount = _accountService.GetAccountForUser(userId);
            if(userAccount != null && !string.IsNullOrEmpty(userAccount.EthereumAddress))
            {
                switch (filter)
                {
                    case TransactionFilter.Inbound:
                        return _moTokenRepository.GetTransactionEventsInbound(userAccount.EthereumAddress, amount, page);
                    case TransactionFilter.Outbound:
                        return _moTokenRepository.GetTransactionEventsOutbound(userAccount.EthereumAddress, amount, page);
                    case TransactionFilter.None:
                        return _moTokenRepository.GetTransactionEvents(userAccount.EthereumAddress, amount, page);
                };
            }
            return new List<Transaction>();
        }

    }
}
