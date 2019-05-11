using RateIt.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RateItWebApi.Models
{
    public class CommentListModel
    {
        [Required]
        [Display(Name = "Comments")]
        public IList<Comment> Comments { get; set; }

        [Required]
        [Display(Name = "Page")]
        public int Page { get; set; }

        [Required]
        [Display(Name = "PerPage")]
        public int PerPage { get; set; }
    }
}