using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Common.Models
{
    public class PageContents
    {
        public long SiteId { get; set; }
        public long SubDirectoryId { get; set; }
        public IList<PageContent> Contents { get; set; }
        public int Page { get; set; }

        public PageContents()
        {
            Contents = new List<PageContent>();
        }
    }
}
