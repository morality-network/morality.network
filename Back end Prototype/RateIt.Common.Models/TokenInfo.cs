using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Common.Models
{
    public class TokenInfo
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public BigInteger TotalSupply {get;set;}
        public decimal TotalSupplyDecimal { get; set; }
        public string Creator {get;set;}
    }
}
