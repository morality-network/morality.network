using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RateItWebApi.Models
{
    public class RatingModel
    {
        [Required]
        [Display(Name = "Rating")]
        public double Rating { get; set; }
    }
}