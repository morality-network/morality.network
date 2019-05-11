using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RateItWebApi.Models
{
    public class CreateCommentModel
    {
        [Required]
        [Display(Name = "EncodedUrl")]
        public string EncodedUrl { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "ParentId")]
        public Nullable<long> ParentId { get; set; }
    }
}