using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface ICurrencyService
    {
        IList<Currency> GetCurrencies(bool activeOnly);
        IList<Currency> GetAllTestCurrencies(bool activeOnly);
        IList<Currency> GetAllLiveCurrencies(bool activeOnly);
        Currency GetLiveCurrency();
        Currency GetTestCurrency();
    }
}
