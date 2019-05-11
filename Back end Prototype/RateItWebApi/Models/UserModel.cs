using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RateItWebApi.Models
{
    public class UserModel
    {
        [Required]
        [Display(Name = "Bio")]
        public string Bio { get; set; }

        [Required]
        [Display(Name = "FullName")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "ProfilePictureUrl")]
        public string ProfilePictureUrl { get; set; }
    }
}