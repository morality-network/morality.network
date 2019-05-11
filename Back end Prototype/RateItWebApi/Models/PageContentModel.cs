using RateIt.Common.Models;
using RateIt.Common.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RateItWebApi.Models
{
    public class PageContentModel
    {
        [Required]
        [Display(Name = "EncodedUrl")]
        public string EncodedUrl { get; set; }

        [Required]
        [Display(Name = "Page")]
        public int Page { get; set; }

        [Display(Name = "Filter")]
        public ContentTypeMap Filter { get; set; }

        public PageContentModel()
        {
            Page = 0;
        }
    }
}