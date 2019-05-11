using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateItHome.Models
{
    public class CurrencyModel
    {
        public IList<Currency> Currencies { get; set; }
        public string CSS { get; set; }

        public CurrencyModel()
        {
            Currencies = new List<Currency>();
            CSS = "trans-dd";
        }
    }
}