using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Common.Models
{
    public class MintCollectionArguments
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CollectionName { get; set; }
        public string CollectionOwner { get; set; }
        public BigInteger TotalToMint { get; set; }
        public double TokenPrice { get; set; }
    }
}
