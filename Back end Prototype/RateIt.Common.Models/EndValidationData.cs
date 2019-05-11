using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Common.Models
{
    public class EndValidationData
    {
        public IList<UserContentValidation> UserValidations {get;set;}
        public UserContentValidation UserValidation  {get;set;}
        public double TotalValues  {get;set;}
        public double ForValues  {get;set;}
        public double ForPercent { get;set;}
        public double AgainstValues { get;set;}
        public double AgainstPercent { get;set;}
        public Account Admin {get;set;}
    }
}
