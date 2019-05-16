using RateIt.Common.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Common.Models
{
    public class PageContent
    {
        public long ContentId { get; set; }
        public long SiteId { get; set; }
        public long SubDirectoryId { get; set; }
        public ContentTypeMap ContentType { get; set; }
        public Comment Comment { get; set; }
        public Survey Surveys { get; set; }
        public Poll Polls { get; set; }
        public CrowdfundingCampaign CrowdFundingCampaign { get; set; }
        public DateTime TimestampCreated { get; set; }
    }
}
