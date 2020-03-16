using RateIt.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace RateItWebApi.Models
{
    public class AppModel
    {
        [Display(Name = "PageId")]
        public long PageId { get; set; }

        [Display(Name = "PageDescription")]
        public string PageDescription { get; set; }

        [Required]
        [Display(Name = "Comments")]
        public CommentListModel Comments { get; set; }

        [Required]
        [Display(Name = "PageName")]
        public string PageName { get; set; }

        [Required]
        [Display(Name = "HostName")]
        public string HostName { get; set; }

        [Required]
        [Display(Name = "PageRating")]
        public double PageRating { get; set; }

        [Required]
        [Display(Name = "PageRatingCount")]
        public int PageRatingCount { get; set; }

        [Required]
        [Display(Name = "Profile")]
        public UserProfile Profile { get; set; }

        public AppModel()
        {
            PageDescription = "None Set";
        }
    }
}