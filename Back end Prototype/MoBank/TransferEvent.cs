using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBank
{
    public class TransferEvent
    {
        [Parameter("address", "from", 1, true)]
        public int From { get; set; }

        [Parameter("address", "to", 2, true)]
        public string To { get; set; }

        [Parameter("uint256", "value", 3, false)]
        public int Value { get; set; }
    }
}
