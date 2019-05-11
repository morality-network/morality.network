using RateIt.Common.Models;
using RateIt.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RateItWebApi.Models
{
    public class AppModel
    {
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
    }
}