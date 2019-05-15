using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Common.Models
{
    public class MoralityTokenSettings
    {
        public string TokenAbi { get; set; }
        public string StorageAbi { get; set; }
        public string CrowdAbi { get; set; }
        public string PlayersAbi { get; set; }
        public string InfuraAddress { get; set; }
        public string AdminAddress { get; set; }
        public string AdminPass { get; set; }
        public string ContractAddress { get; set; }
        public string PlayersAddress { get; set; }
        public string WrapperAddress { get; set; }
        public string StorageAddress { get; set; }

        public MoralityTokenSettings()
        {}
    }
}
