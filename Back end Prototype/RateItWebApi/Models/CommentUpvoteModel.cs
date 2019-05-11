using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RateItWebApi.Models
{
    public class CommentUpvoteModel
    {
        [Required]
        [Display(Name = "Upvote")]
        public bool Upvote { get; set; }

        [Required]
        [Display(Name = "CommentId")]
        public long CommentId { get; set; }
    }
}