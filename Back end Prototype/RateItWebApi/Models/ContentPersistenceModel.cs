using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RateItWebApi.Models
{
    public class ContentPersistenceModel
    {
        [Required]
        [Display(Name = "ContentId")]
        public long ContentId { get; set; }
    }
}