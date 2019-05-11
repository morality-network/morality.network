using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Common.Models
{
    public class RawPageContent
    {
        public string Data { get; set; }
        public long ArticleId { get; set; }
        public long SubArticleId { get; set; }
        public long ContentId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
