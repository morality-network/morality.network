using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RateItWebApi.Models
{
    public class TransactionModel
    {
        [Required]
        [Display(Name = "UserFromId")]
        public long UserFromId { get; set; }

        [Required]
        [Display(Name = "UserToId")]
        public long UserToId { get; set; }

        [Required]
        [Display(Name = "AmountToSend")]
        public double AmountToSend { get; set; }
    }
}