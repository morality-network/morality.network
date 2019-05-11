using Nethereum.StandardTokenEIP20;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.Hex.HexTypes;
using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;
using System.Numerics;
using Nethereum.Web3.Accounts.Managed;
using System.Net;
using BlockChainTest;
using Bank;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Web3.Accounts;
using Nethereum.ABI.Model;
using Transaction = Nethereum.RPC.Eth.DTOs.Transaction;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts.CQS;
using RateIt.Utilities;
using RateIt.Common.Models;
using MoBank.Interfaces;

namespace MoBank
{
    public class MoralityTokenBank : StandardTokenService, IMoralityTokenBank
    {
        private string _infura;
        private string _contractAddress;
        private string _abi;
        private string _ownerAddress;

        public MoralityTokenBank(Web3 web3, string contractAddress, string infura, string abi, string ownerAddress) : base(web3, contractAddress)
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

        public HexBigInteger GetBlockNumber()
        {
            return AsyncHelper.RunSync(() => Web3.Eth.Blocks.GetBlockNumber.SendRequestAsync());
        }

        public double GetMoBalance(string address)
        {
            return AsyncHelper.RunSync(() => GetMoBalanceAsync(address));
        }

        private async Task<double> GetMoBalanceAsync(string address)
        {
            var contract = GetContract();
            var balanceOfFunction = contract.GetFunction("balanceOf");
            var balance = await balanceOfFunction.CallAsync<BigInteger>(address);
            return (double)Web3.Convert.FromWei(balance);
        }

        private async Task<HexBigInteger> GetGas<T>(Function function, string addressFrom, string addressTo, T value)
        {
            var gas = await function.EstimateGasAsync(addressFrom, null, null, addressTo, value);
            return gas;
        }

        public async Task<TransactionReceipt> Transfer(string addressTo, double value)
        {
            BigInteger valueWei = Web3.Convert.ToWei((decimal)value);
            var contract = GetContract();
            var transferFunction = contract.GetFunction("transfer");
            var gas = await GetGas<BigInteger>(transferFunction, _ownerAddress, addressTo, valueWei);
            var tx = await transferFunction.SendTransactionAndWaitForReceiptAsync(_ownerAddress, gas, null, null, addressTo, valueWei);
            return tx;
        }

        public async Task<string> TransferEth(string addressTo, double value)
        {
            BigInteger valueWei = Web3.Convert.ToWei((decimal)value);
            var gas = await Web3.Eth.TransactionManager.EstimateGasAsync(new CallInput()
            {
                From = _ownerAddress,
                To = addressTo,
                Value = new HexBigInteger(valueWei)
            });
            var tx = await Web3.Eth.TransactionManager.SendTransactionAsync(new TransactionInput()
            {
                From = _ownerAddress,
                To = addressTo,
                Value = new HexBigInteger(valueWei),
                Gas = gas
            });
            return tx;
        }

        private async Task<TokenInfo> GetTokenInfoAsyncCall()
        {
            var contract = GetContract();
            var address = await ContractHandler.QueryAsync<CreatorFunction, string>(new CreatorFunction());
            var symbol = await ContractHandler.QueryAsync<SymbolFunction, string>(new SymbolFunction());
            var tokenName = await ContractHandler.QueryAsync<NameFunction, string>(new NameFunction());
            var totalSupply = await ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(new TotalSupplyFunction());
            var totalSupplyDecimal = Web3.Convert.FromWei(totalSupply);
            return new TokenInfo()
            {
                Name = tokenName,
                Symbol = symbol,
                Creator = address,
                TotalSupply = totalSupply,
                TotalSupplyDecimal = totalSupplyDecimal
            };
        }

        public TokenInfo GetTokenInfo()
        {
            return AsyncHelper.RunSync(() => GetTokenInfoAsyncCall());
        }

        public async Task<bool> SetInfo(string name, string symbol)
        {
            var infoFunction = new SetTokenInformationFunction();
            infoFunction.Name = name;
            infoFunction.Symbol = symbol;
            var complete2 = await ContractHandler.SendRequestAsync<SetTokenInformationFunction>(infoFunction);
            return true;
        }

        public async Task<string> Withdraw(double amountRaw)
        {
            var amount = Web3.Convert.ToWei(amountRaw);
            var withdraw = GetContract().GetFunction("withdraw");
            var gas = await withdraw.EstimateGasAsync(_ownerAddress, null, null, amount);
            var trans = await withdraw.SendTransactionAsync(_ownerAddress, gas, (HexBigInteger)null, amount);
            return trans;
        }

        public async Task<string> Burn(double amountRaw)
        {
            var amount = Web3.Convert.ToWei(amountRaw);
            var mint = GetContract().GetFunction("burn");
            var gas = await mint.EstimateGasAsync(_ownerAddress, null, null, amount);
            var trans = await mint.SendTransactionAsync(_ownerAddress, gas, (HexBigInteger)null, amount);
            return trans;
        }

        public async Task<string> Mint(string target, double amountRaw)
        {
            var amount = Web3.Convert.ToWei(amountRaw);
            var mint = GetContract().GetFunction("mintToken");
            var gas = await mint.EstimateGasAsync(_ownerAddress, null, null, target, amount);
            var trans = await mint.SendTransactionAsync(_ownerAddress, gas, (HexBigInteger)null, target, amount);
            return trans;
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

        //Content<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
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

        public async Task<string> AddContentViaStruct(long articleId, long subArticleId, long contentId, string rawData)
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

        public async Task<RawPageContent> GetContentByIdStruct(long contentId)
        {
            var contract = GetContract();
            var content = await ContractHandler.QueryDeserializingToObjectAsync<ContentStructFunction, ContentStructOutputDTO>(new ContentStructFunction()
            {
                ContentId = contentId
            });
            if (content != null && content.Contents != null && content.Contents.ContentId > 0)
                return new RawPageContent()
                {
                    ArticleId = (long)content.Contents.ArticleId,
                    ContentId = (long)content.Contents.ContentId,
                    Data = content.Contents.Data,
                    SubArticleId = (long)content.Contents.SubArticleId,
                    Timestamp = new DateTime((long)content.Contents.Timestamp)
                };
            return null;
        }

        public async Task<IList<BigInteger>> GetAllContentIdsStruct()
        {
            var contract = GetContract();
            var contentIds = await ContractHandler.QueryAsync<ContentIdsStructFunction, List<BigInteger>>(new ContentIdsStructFunction()
            { });
            return contentIds;
        }

        public async Task<IList<RawPageContent>> GetContentByArticleIdStruct(long articleId)
        {
            var contract = GetContract();
            var content = await ContractHandler.QueryDeserializingToObjectAsync<ContentArticleStructFunction, ContentListStructOutputDTO>(new ContentArticleStructFunction()
            {
                ArticleId = articleId
            });
            if (content != null)
                return content.Contents.Select(x => new RawPageContent()
                {
                    ArticleId = (long)x.ArticleId,
                    ContentId = (long)x.ContentId,
                    Data = x.Data,
                    SubArticleId = (long)x.SubArticleId,
                    Timestamp = new DateTime((long)x.Timestamp)
                }).ToList();
            return new List<RawPageContent>();
        }

        public async Task<IList<RawPageContent>> GetContentBySubArticleIdStruct(long subArticleId)
        {
            var contract = GetContract();
            var content = await ContractHandler.QueryDeserializingToObjectAsync<ContentSubArticleStructFunction, ContentListStructOutputDTO>(new ContentSubArticleStructFunction()
            {
                SubArticleId = subArticleId
            });
            if (content != null)
                return content.Contents.Select(x => new RawPageContent()
                {
                    ArticleId = (long)x.ArticleId,
                    ContentId = (long)x.ContentId,
                    Data = x.Data,
                    SubArticleId = (long)x.SubArticleId,
                    Timestamp = new DateTime((long)x.Timestamp)
                }).ToList();
            return new List<RawPageContent>();
        }

        public async Task<BigInteger> CountAllContentForSubArticleStruct(long subArticleId)
        {
            var contract = GetContract();
            var contentCount = await ContractHandler.QueryAsync<CountSubArticleContentFunction, BigInteger>(new CountSubArticleContentFunction()
            {
                SubArticleId = subArticleId
            });
            return contentCount;
        }

        public async Task<BigInteger> CountAllContentForArticleStruct(long articleId)
        {
            var contract = GetContract();
            var contentCount = await ContractHandler.QueryAsync<CountArticleContentFunction, BigInteger>(new CountArticleContentFunction()
            {
                ArticleId = articleId
            });
            return contentCount;
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

        public async Task<IList<EventLog<TransferEventDTO>>> GetTransactionEventsInbound(string ethereumAddress, int amount, int page)
        {
            var allTransactions = await GetAllTransactionEvents();
            if(allTransactions != null)
                return allTransactions
                    .Where(x => x.Event.To == ethereumAddress)
                    .Skip(amount * page)
                    .Take(amount)
                    .ToList();
            return new List<EventLog<TransferEventDTO>>();
        }

        public async Task<IList<EventLog<TransferEventDTO>>> GetTransactionEventsOutbound(string ethereumAddress, int amount, int page)
        {
            var allTransactions = await GetAllTransactionEvents();
            if (allTransactions != null)
                return allTransactions
                    .Where(x => x.Event.From == ethereumAddress)
                    .Skip(amount * page)
                    .Take(amount)
                    .ToList();
            return new List<EventLog<TransferEventDTO>>();
        }

        public async Task<IList<EventLog<TransferEventDTO>>> GetTransactionEvents(string ethereumAddress, int amount, int page)
        {
            var allTransactions = await GetAllTransactionEvents();
            if (allTransactions != null)
                return allTransactions
                    .Skip(amount * page)
                    .Take(amount)
                    .ToList();
            return new List<EventLog<TransferEventDTO>>();
        }

        //Get all for now since infura doesnt support filters (commented line)
        public async Task<IList<EventLog<TransferEventDTO>>> GetAllTransactionEvents()
        {
            var contract = GetContract();
            var contentEventHandler = contract.GetEvent("ContentAddedViaEvent");
            var firstBlock = BlockParameter.CreateEarliest();
            var lastBlock = BlockParameter.CreateLatest();
            var filterAllEventsForContract = contentEventHandler.CreateFilterInput(firstBlock, lastBlock);
            //var filterAllEventsForContract = await contentEventHandler.CreateFilterAsync(2, 2, firstBlock, lastBlock);
            return await contentEventHandler.GetAllChanges<TransferEventDTO>(filterAllEventsForContract);
        }

        public decimal ConvertToDecimal(BigInteger value)
        {
            if(value != null)
                return Web3.Convert.FromWei(value);
            return 0;
        }

    }
}
