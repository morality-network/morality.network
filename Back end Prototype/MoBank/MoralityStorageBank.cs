using Bank;
using MoBank.Interfaces;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.StandardTokenEIP20;
using Nethereum.Web3;
using RateIt.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static MoBank.StorageContractFunctions;

namespace MoBank
{
    public class MoralityStorageBank : StandardTokenService, IMoralityStorageBank
    {
        private string _infura;
        private string _contractAddress;
        private string _abi;
        private string _ownerAddress;

        public MoralityStorageBank(Web3 web3, string contractAddress, string infura, string abi, string ownerAddress) : base(web3, contractAddress)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            _infura = infura;
            _contractAddress = contractAddress;
            _abi = abi;
            _ownerAddress = ownerAddress;
        }

        public Nethereum.Contracts.Contract GetContract()
        {
            return Web3.Eth.GetContract(_abi, _contractAddress);
        }

        //Moderator<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        public async Task<string> AddModerator(string address)
        {
            var contract = GetContract();
            var addModerator = contract.GetFunction("addModerator");
            var gas = await addModerator.EstimateGasAsync(_ownerAddress, null, null, address);
            var call = await addModerator.SendTransactionAsync(_ownerAddress, gas, (HexBigInteger)null, address);
            return call;
        }

        public async Task<string> RemoveModerator(string address)
        {
            var contract = GetContract();
            var addModerator = contract.GetFunction("removeModerator");
            var gas = await addModerator.EstimateGasAsync(_ownerAddress, null, null, address);
            var call = await addModerator.SendTransactionAsync(_ownerAddress, gas, (HexBigInteger)null, address);
            return call;
        }

        public async Task<bool> DoesModeratorExist(string address)
        {
            var isModerator = await ContractHandler.QueryAsync<ModeratorFunction, bool>(new ModeratorFunction()
            {
                Address = address
            });
            return isModerator;
        }

        //Content Via Events<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        public async Task<string> AddContentViaEvent(long articleId, long subArticleId, long contentId, string rawData)
        {
            var data = rawData;
            var timeStamp = new BigInteger(DateTime.Now.Ticks);
            var contract = GetContract();
            var addContent = contract.GetFunction("addContentViaEvent");
            var bigIntArticleId = new BigInteger(articleId);
            var bigIntSubArticleId = new BigInteger(subArticleId);
            var bigIntContentId = new BigInteger(contentId);
            var gas = await addContent.EstimateGasAsync(_ownerAddress, null, null, _ownerAddress, bigIntArticleId, bigIntSubArticleId,
                bigIntContentId, timeStamp, data);
            var call = await addContent.SendTransactionAsync(_ownerAddress, gas, (HexBigInteger)null, _ownerAddress,
                bigIntArticleId, bigIntSubArticleId, bigIntContentId, timeStamp, data);
            return call;
        }

        //FOR ALL BELOW<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        //When we have enough to host Geth on Azure, I can use the contract event filter
        //For now, we have to get all and filter in memory
        //I use infura for now and they don't support the filter rpc method
        public async Task<IList<RawPageContent>> GetContentByArticleEvent(long articleId)
        {
            var events = await GetAddContentEvents();
            var articleIdBigInt = new BigInteger(articleId);
            var contents = events
                .Where(x => x.Event.ArticleId == articleIdBigInt);
            if (contents.Any())
                return contents.OrderBy(x => x.Event.Timestamp).Select(x => new RawPageContent()
                {
                    Data = x.Event.Data,
                    ArticleId = (long)x.Event.ArticleId,
                    ContentId = (long)x.Event.ContentId,
                    SubArticleId = (long)x.Event.SubArticleId,
                    Timestamp = new DateTime((long)x.Event.Timestamp)
                }).ToList();
            return null;
        }

        public async Task<IList<RawPageContent>> GetContentBySubArticleEvent(long subArticleId)
        {
            var events = await GetAddContentEvents();
            var subArticleIdBigInt = new BigInteger(subArticleId);
            var contents = events
                .Where(x => x.Event.SubArticleId == subArticleIdBigInt);
            if (contents.Any())
                return contents.OrderBy(x => x.Event.Timestamp)
                    .Select(x => new RawPageContent()
                    {
                        Data = x.Event.Data,
                        ArticleId = (long)x.Event.ArticleId,
                        ContentId = (long)x.Event.ContentId,
                        SubArticleId = (long)x.Event.SubArticleId,
                        Timestamp = new DateTime((long)x.Event.Timestamp)
                    }).ToList();
            return null;
        }

        public async Task<RawPageContent> GetExactContentEvent(long contentId)
        {
            var events = await GetAddContentEvents();
            var contentIdBigInt = new BigInteger(contentId);
            var contents = events.Where(x => x.Event.ContentId == contentIdBigInt);
            if (contents.Any())
            {
                var content = contents.OrderBy(x => x.Event.Timestamp).FirstOrDefault();
                return new RawPageContent()
                {
                    Data = content.Event.Data,
                    ArticleId = (long)content.Event.ArticleId,
                    ContentId = (long)content.Event.ContentId,
                    SubArticleId = (long)content.Event.SubArticleId,
                    Timestamp = new DateTime((long)content.Event.Timestamp)
                };
            }
            return null;
        }

        //Get all for now since infura doesnt support filters (commented line)
        public async Task<List<EventLog<ContentEventDTO>>> GetAddContentEvents()
        {
            var contract = GetContract();
            var contentEventHandler = contract.GetEvent("ContentAddedViaEvent");
            var firstBlock = BlockParameter.CreateEarliest();
            var lastBlock = BlockParameter.CreateLatest();
            var filterAllEventsForContract = contentEventHandler.CreateFilterInput(firstBlock, lastBlock);
            //var filterAllEventsForContract = await contentEventHandler.CreateFilterAsync(2, 2, firstBlock, lastBlock);
            return await contentEventHandler.GetAllChanges<ContentEventDTO>(filterAllEventsForContract);
        }

        //Content<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        public async Task<string> AddContent(long articleId, long subArticleId, long contentId, string rawData)
        {
            var data = rawData;
            var timeStamp = new BigInteger(DateTime.Now.Ticks);
            var contract = GetContract();
            var addContent = contract.GetFunction("addContent");
            var bigIntArticleId = new BigInteger(articleId);
            var bigIntSubArticleId = new BigInteger(subArticleId);
            var bigIntContentId = new BigInteger(contentId);
            var gas = await addContent.EstimateGasAsync(_ownerAddress, null, null, _ownerAddress, bigIntArticleId, bigIntSubArticleId,
                bigIntContentId, timeStamp, data);
            var call = await addContent.SendTransactionAsync(_ownerAddress, gas, (HexBigInteger)null, _ownerAddress,
                bigIntArticleId, bigIntSubArticleId, bigIntContentId, timeStamp, data);
            return call;
        }

        public async Task<RawPageContent> GetContentById(long contentId)
        {
            var contract = GetContract();
            var content = await ContractHandler.QueryAsync<ContentByIdFunction, string>(new ContentByIdFunction()
            { ContentId = contentId });
            if (!string.IsNullOrEmpty(content))
                return new RawPageContent()
                {
                    ContentId = contentId,
                    Data = content
                };
            return null;
        }

        public async Task<List<BigInteger>> GetAllContentIds()
        {
            var contract = GetContract();
            var getAllContentIdsFunction = contract.GetFunction("getAllContentIds");
            var contentIds = await getAllContentIdsFunction.CallAsync<List<BigInteger>>();
            return contentIds;
        }

        public async Task<List<BigInteger>> GetAllContentIdsForArticle(long articleId)
        {
            var contract = GetContract();
            var contentIds = await ContractHandler.QueryAsync<ContentArticleIdsFunction, List<BigInteger>>(
                new ContentArticleIdsFunction(){ ArticleId = articleId });
            if (contentIds != null)
                return contentIds;
            return null;
        }

        public async Task<List<BigInteger>> GetAllContentIdsForSubArticle(long subArticleId)
        {
            var contract = GetContract();
            var contentIds = await ContractHandler.QueryAsync<ContentSubArticleIdsFunction, List<BigInteger>>(
                new ContentSubArticleIdsFunction() { SubArticleId = subArticleId });
            if (contentIds != null)
                return contentIds;
            return null;
        }

        public async Task<BigInteger> CountAllContentForArticle(long articleId)
        {
            var contract = GetContract();
            var contentCount = await ContractHandler.QueryAsync<CountArticleContentFunction, BigInteger>(new CountArticleContentFunction()
            { ArticleId = articleId });
            return contentCount;
        }

        public async Task<BigInteger> CountAllContentForSubArticle(long subArticleId)
        {
            var contract = GetContract();
            var contentCount = await ContractHandler.QueryAsync<CountSubArticleContentFunction, BigInteger>(new CountSubArticleContentFunction()
            { SubArticleId = subArticleId });
            return contentCount;
        }

        public async Task<IList<RawPageContent>> GetContentByArticleId(long articleId, int page)
        {
            var contract = GetContract();
            var getPageForArticleFunction = contract.GetFunction("getPageForArticle");
            var content = await getPageForArticleFunction.CallDeserializingToObjectAsync<ContentPage>(articleId, page);
            if (content != null)
            {
                var contents = new List<RawPageContent>();
                contents.Add(new RawPageContent() { Page = page, Data = content.PageItem1 });
                contents.Add(new RawPageContent() { Page = page, Data = content.PageItem2 });
                contents.Add(new RawPageContent() { Page = page, Data = content.PageItem3 });
                contents.Add(new RawPageContent() { Page = page, Data = content.PageItem4 });
                contents.Add(new RawPageContent() { Page = page, Data = content.PageItem5 });
                contents.Add(new RawPageContent() { Page = page, Data = content.PageItem6 });
                return contents.Where(x => !string.IsNullOrEmpty(x.Data))
                    .ToList();
            }
            return new List<RawPageContent>();
        }

        public async Task<IList<RawPageContent>> GetContentBySubArticleId(long subArticleId, int page)
        {
            var contract = GetContract();
            var getPageForArticleFunction = contract.GetFunction("getPageForSubArticle");
            var content = await getPageForArticleFunction.CallDeserializingToObjectAsync<ContentPage>(subArticleId, page);
            if (content != null)
            {
                var contents = new List<RawPageContent>();
                contents.Add(new RawPageContent() { Page = page, Data = content.PageItem1 });
                contents.Add(new RawPageContent() { Page = page, Data = content.PageItem2 });
                contents.Add(new RawPageContent() { Page = page, Data = content.PageItem3 });
                contents.Add(new RawPageContent() { Page = page, Data = content.PageItem4 });
                contents.Add(new RawPageContent() { Page = page, Data = content.PageItem5 });
                contents.Add(new RawPageContent() { Page = page, Data = content.PageItem6 });
                return contents.Where(x => !string.IsNullOrEmpty(x.Data))
                    .ToList();
            }
            return new List<RawPageContent>();
        }
    }
}
