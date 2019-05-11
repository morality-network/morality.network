using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RateItWebApi.Models
{
    public class CommentModel
    {
        [Required]
        [Display(Name = "EncodedUrl")]
        public string EncodedUrl { get; set; }

        [Required]
        [Display(Name = "Page")]
        public int Page { get; set; }

        [Display(Name = "SearchTerm")]
        public string SearchTerm { get; set; }

    }
}