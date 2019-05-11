using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateItHome.Models
{
    public class MiningViewModel
    {
        public long UserId { get; set; } 
        public int SelectedId { get; set; }
        public bool IsToxic { get; set; }
        public bool IsSevereToxic { get; set; }
        public bool IsObscence { get; set; }
        public bool IsThreat { get; set; }
        public bool IsInsult { get; set; }
        public bool IsIdentityHate { get; set; }
        public bool IsSpam { get; set; }
        public bool HideReviews { get; set; }
        public bool Remove { get; set; }

        public MiningViewModel()
        {
            HideReviews = true;
        }

        public IList<Investigation> TopInvestigations { get; set; }
    }
}