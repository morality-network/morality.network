using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Common.Models
{
    public class Comment
    {
        public long Id { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime ModifiedAt { get; set; }
        public string Content { get; set; }
        public long ContentId { get; set; }
        public string Pings { get; set; }
        public string Fullname { get; set; }
        public string ProfilePictureUrl { get; set; }
        public bool CreatedByAdmin { get; set; }
        public int UpvoteCount { get; set; }
        public long CreatorId { get; set; }
        public Nullable<long> ParentId { get; set; }
        public string SiteName { get; set; }
        public int FlagCount { get; set; }
        public IList<Comment> SubComments { get; set; }
    }
}
