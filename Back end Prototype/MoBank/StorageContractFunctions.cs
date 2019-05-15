using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MoBank
{
    public class StorageContractFunctions
    {
        public partial class ContentByIdFunction : ContentByIdFunctionBase { }
        [Function("getContentById", "string")]
        public class ContentByIdFunctionBase : FunctionMessage
        {
            [Parameter("uint256", "contentId", 1, false)]
            public BigInteger ContentId { get; set; }
        }

        public partial class ContentArticleIdsFunction : ContentArticleIdsFunctionBase { }
        [Function("getAllContentIdsForArticle", "uint256[]")]//Remove id when deploy
        public class ContentArticleIdsFunctionBase : FunctionMessage
        {
            [Parameter("uint256", "articleId", 1, false)]
            public BigInteger ArticleId { get; set; }
        }

        public partial class ContentSubArticleIdsFunction : ContentSubArticleIdsFunctionBase { }
        [Function("getAllContentIdsForSubArticle", "uint256[]")]//Remove id when deploy
        public class ContentSubArticleIdsFunctionBase : FunctionMessage
        {
            [Parameter("uint256", "subArticleId", 1, false)]
            public BigInteger SubArticleId { get; set; }
        }

        [FunctionOutput]
        public class ContentPage : IFunctionOutputDTO
        {
            [Parameter("string", "pageItem1", 1)]
            public string PageItem1 { get; set; }

            [Parameter("string", "pageItem2", 2)]
            public string PageItem2 { get; set; }

            [Parameter("string", "pageItem3", 3)]
            public string PageItem3 { get; set; }

            [Parameter("string", "pageItem4", 4)]
            public string PageItem4 { get; set; }

            [Parameter("string", "pageItem5", 5)]
            public string PageItem5 { get; set; }

            [Parameter("string", "pageItem6", 6)]
            public string PageItem6 { get; set; }
        }

        public partial class ContentArticleFunction : ContentArticleFunctionBase { }
        [Function("getPageForArticle")]//Remove id when deploy
        public class ContentArticleFunctionBase : FunctionMessage
        {
            [Parameter("uint256", "articleId", 1, false)]
            public BigInteger ArticleId { get; set; }

            [Parameter("uint256", "page", 2, false)]
            public BigInteger Page { get; set; }
        }

        public partial class ContentSubArticleFunction : ContentSubArticleFunctionBase { }
        [Function("getPageForSubArticle", "string")]//Remove id when deploy
        public class ContentSubArticleFunctionBase : FunctionMessage
        {
            [Parameter("uint256", "subArticleId", 1, false)]
            public BigInteger SubArticleId { get; set; }

            [Parameter("uint256", "page", 2, false)]
            public BigInteger Page { get; set; }
        }
    }
}
