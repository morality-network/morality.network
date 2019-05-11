using Bank;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using RateIt.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MoBank.Interfaces
{
    public interface IMoralityTokenBank
    {
        Contract GetContract();
        HexBigInteger GetBlockNumber();
        double GetMoBalance(string address);
        Task<TransactionReceipt> Transfer(string addressTo, double rawValue);
        TokenInfo GetTokenInfo();
        Task<bool> SetInfo(string name, string symbol);
        Task<string> AddContentViaEvent(long articleId, long subArticleId, long contentId, string rawData);
        Task<string> AddContentViaStruct(long articleId, long subArticleId, long contentId, string rawData);
        Task<IList<RawPageContent>> GetContentByArticleEvent(long articleId);
        Task<IList<RawPageContent>> GetContentBySubArticleEvent(long subArticleId);
        Task<RawPageContent> GetExactContentEvent(long contentId);
        Task<List<EventLog<ContentEventDTO>>> GetAddContentEvents();
        Task<RawPageContent> GetContentByIdStruct(long contentId);
        Task<IList<BigInteger>> GetAllContentIdsStruct();
        Task<IList<RawPageContent>> GetContentByArticleIdStruct(long articleId);
        Task<IList<RawPageContent>> GetContentBySubArticleIdStruct(long subArticleId);
        Task<BigInteger> CountAllContentForSubArticleStruct(long subArticleId);
        Task<BigInteger> CountAllContentForArticleStruct(long articleId);
        Task<bool> DoesModeratorExist(string address);
        Task<string> AddModerator(string address);
        Task<string> RemoveModerator(string address);
        Task<string> Withdraw(double amountRaw);
        Task<string> Burn(double amountRaw);
        Task<string> Mint(string target, double amountRaw);
        Task<string> TransferEth(string addressTo, double value);
        Task<IList<EventLog<TransferEventDTO>>> GetTransactionEventsInbound(string ethereumAddress, int amount, int page);
        Task<IList<EventLog<TransferEventDTO>>> GetTransactionEventsOutbound(string ethereumAddress, int amount, int page);
        Task<IList<EventLog<TransferEventDTO>>> GetTransactionEvents(string ethereumAddress, int amount, int page);
        Task<IList<EventLog<TransferEventDTO>>> GetAllTransactionEvents();
        decimal ConvertToDecimal(BigInteger value);
    }
}
