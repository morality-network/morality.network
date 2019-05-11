using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Common.Models
{
    public class Mining
    {
        public bool IsToxic { get; set; }
        public bool IsRacism { get; set; }
        public bool IsSevereToxic { get; set; }
        public bool IsObscence { get; set; }
        public bool IsThreat { get; set; }
        public bool IsInsult { get; set; }
        public bool IsIdentityHate { get; set; }
        public bool IsSpam { get; set; }
        public bool Remove { get; set; }
    }
}
