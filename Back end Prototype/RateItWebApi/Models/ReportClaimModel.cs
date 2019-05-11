using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RateItWebApi.Models
{
    public class ReportClaimModel
    {
        [Required]
        [Display(Name = "CommentId")]
        public int CommentId { get; set; }
    }
}