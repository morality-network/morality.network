using Nethereum.ABI.Decoders;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using Nethereum.Contracts.CQS;
using Nethereum.Hex.HexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    [Event("ContentAddedViaEvent")]
    public class ContentEventDTO : IEventDTO
    {
        [Parameter("address", "contentCreator", 0, false)]
        public string ContentCreator { get; set; }

        [Parameter("uint256", "articleId", 1, true)]
        public BigInteger ArticleId { get; set; }

        [Parameter("uint256", "subArticleId", 2, true)]
        public BigInteger SubArticleId { get; set; }

        [Parameter("uint256", "contentId", 3, true)]
        public BigInteger ContentId { get; set; }

        [Parameter("uint256", "timestamp", 4, false)]
        public BigInteger Timestamp { get; set; }

        [Parameter("string", "data", 5, false)]
        public string Data { get; set; }
    }

    [Event("Transfer")]
    public class TransferEventDTO : IEventDTO
    {
        [Parameter("address", "from", 1, true)]
        public string From { get; set; }

        [Parameter("address", "to", 2, true)]
        public string To { get; set; }

        [Parameter("uint256", "value", 3, false)]
        public BigInteger Value { get; set; }
    }

    //Functions
    public partial class WalletFunction : WalletFunctionBase { }
    [Function("wallet", "address")]
    public class WalletFunctionBase : FunctionMessage
    { }

    //Functions
    public partial class ModeratorFunction : ModeratorFunctionBase { }
    [Function("moderators", "bool")]
    public class ModeratorFunctionBase : FunctionMessage
    {
        [Parameter("address", "address", 1, true)]
        public string Address { get; set; }
    }

    //Functions
    public partial class AddModeratorFunction : AddModeratorFunctionBase { }
    [Function("addModerator", "bool")]
    public class AddModeratorFunctionBase : FunctionMessage
    { 
        [Parameter("address", "_newModerator", 1, true)]
        public string Address { get; set; }
    }

    public partial class CreatorFunction : CreatorFunctionBase { }
    [Function("creator", "address")]
    public class CreatorFunctionBase : FunctionMessage
    { }

    public partial class ContentIdsStructFunction : ContentIdsStructFunctionBase { }
    [Function("getAllContentIds", "uint256[]")]
    public class ContentIdsStructFunctionBase : FunctionMessage
    {
    }

    public partial class ContentStructFunction : ContentStructFunctionBase { }
    [Function("getContentById", "tuple")]
    public class ContentStructFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "contentId", 1, false)]
        public BigInteger ContentId { get; set; }
    }

    public partial class ContentArticleStructFunction : ContentArticleStructFunctionBase { }
    [Function("getAllContentForArticle", "tuple[]")]//Remove id when deploy
    public class ContentArticleStructFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "articleId", 1, false)]
        public BigInteger ArticleId { get; set; }
    }

    public partial class ContentSubArticleStructFunction : ContentSubArticleStructFunctionBase { }
    [Function("getAllContentForSubArticle", "tuple[]")]
    public class ContentSubArticleStructFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "subArticleId", 1, false)]
        public BigInteger SubArticleId { get; set; }
    }

    [FunctionOutput]
    public class ContentDTO : IFunctionOutputDTO
    {
        [Parameter("address", "contentCreator", 0, false)]
        public virtual string ContentCreator { get; set; }

        [Parameter("uint256", "articleId", 1, false)]
        public virtual BigInteger ArticleId { get; set; }

        [Parameter("uint256", "subArticleId", 2, false)]
        public virtual BigInteger SubArticleId { get; set; }

        [Parameter("uint256", "contentId", 3, false)]
        public virtual BigInteger ContentId { get; set; }

        [Parameter("uint256", "timestamp", 4, false)]
        public virtual BigInteger Timestamp { get; set; }

        [Parameter("string", "data", 5, false)]
        public virtual string Data { get; set; }
    }

    [FunctionOutput]
    public class ContentStructOutputDTO : IFunctionOutputDTO
    {
        [Parameter("tuple")]
        public ContentDTO Contents { get; set; }
    }

    [FunctionOutput]
    public class ContentListStructOutputDTO : IFunctionOutputDTO
    {
        [Parameter("tuple[]")]
        public List<ContentDTO> Contents { get; set; }
    }

    public partial class SymbolFunction : SymbolFunctionBase { }
    [Function("symbol", "string")]
    public class SymbolFunctionBase : FunctionMessage
    { }

    public partial class CountSubArticleContentFunction : CountSubArticleContentFunctionBase { }
    [Function("countContentForSubArticle", "uint256")]
    public class CountSubArticleContentFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "subArticleId", 1)]
        public BigInteger SubArticleId { get; set; }
    }

    public partial class CountArticleContentFunction : CountArticleContentFunctionBase { }
    [Function("countContentForArticle", "uint256")]
    public class CountArticleContentFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "ArticleId", 1)]
        public BigInteger ArticleId { get; set; }
    }

    public partial class NameFunction : NameFunctionBase { }
    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
    { }

    public partial class TotalSupplyFunction : TotalSupplyFunctionBase { }
    [Function("totalSupply", "uint256")]
    public class TotalSupplyFunctionBase : FunctionMessage
    { }


    public partial class RateFunction : RateFunctionBase { }
    [Function("rate", "uint256")]
    public class RateFunctionBase : FunctionMessage
    { }

    public partial class BuyTokensFunction : BuyTokensFunctionBase { }
    [Function("buyTokens")]
    public class BuyTokensFunctionBase : FunctionMessage
    {
        [Parameter("address", "beneficiary", 1)]
        public virtual string Beneficiary { get; set; }
        [Parameter("uint256", "value", 1)]
        public virtual BigInteger Value { get; set; }
        [Parameter("uint256", "payableAmount", 1)]
        public virtual BigInteger PayableAmount { get; set; }
    }

    public partial class WeiRaisedFunction : WeiRaisedFunctionBase { }
    [Function("weiRaised", "uint256")]
    public class WeiRaisedFunctionBase : FunctionMessage
    { }

    public partial class TransferFunction : TransferFunctionBase { }
    [Function("transfer", "bool")]
    public class TransferFunctionBase : FunctionMessage
    {
        [Parameter("address", "_to", 1)]
        public string To { get; set; }

        [Parameter("uint256", "_value", 2)]
        public BigInteger TokenAmount { get; set; }
    }

    public partial class SetTokenInformationFunction : SetTokenInformationFunctionBase { }
    [Function("setTokenInformation")]
    public class SetTokenInformationFunctionBase : FunctionMessage
    {
        [Parameter("string memory", "_name", 1)]
        public string Name { get; set; }

        [Parameter("string memory", "_symbol", 2)]
        public string Symbol { get; set; }
    }

}
