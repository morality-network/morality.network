using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RateItWebApi.Models
{
    public class PageModel
    {
        [Required]
        [Display(Name = "PerPage")]
        public int PerPage { get; set; }

        [Required]
        [Display(Name = "PageNum")]
        public int PageNum { get; set; }
    }
}