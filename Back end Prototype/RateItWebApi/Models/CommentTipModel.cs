using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RateItWebApi.Models
{
    public class CommentTipModel
    {
        [Required]
        [Display(Name = "Amount")]
        public double Amount { get; set; }

        [Required]
        [Display(Name = "CommentId")]
        public long CommentId { get; set; }
    }
}