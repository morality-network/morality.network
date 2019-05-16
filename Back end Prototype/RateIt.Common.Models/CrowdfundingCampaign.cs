using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Common.Models
{
    public class CrowdfundingCampaign
    {
        public long ContentId { get; set; }
        public long CreatorId { get; set; }
        public string CreatorName { get; set; }
        public string Description { get; set; }
        public double Target { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public long ParticipantCount { get; set; }
        public double AmountRaisedUSD { get; set; }
        public double MeanDonation { get; set; }
        public double ModeDonation { get; set; }
        public double MedianDonation { get; set; }
        public string CrowdfundEthereumAddress { get; set; }
    }
}
