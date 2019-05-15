using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBank
{
    public class MoralityPlayersContractFunctions
    {
        public partial class CollectionItemPriceFunction : CollectionItemPriceFunctionBase { }
        [Function("collectionPricePerUnit", "uint256")]
        public class CollectionItemPriceFunctionBase : FunctionMessage
        {
            public string Input { get; set; }
        }

    }
}
