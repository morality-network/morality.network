using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RateIt.Services.Interfaces;
using RateIt.Repositories.Interfaces;

namespace RateIt.Services
{
    public class CurrencyService: ICurrencyService
    {
        private readonly IRepository<Currency> _currencyRepository;

        public CurrencyService(IRepository<Currency> currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public IList<Currency> GetCurrencies(bool activeOnly)
        {
            var all = _currencyRepository.GetAll();
            if (activeOnly) all = all.Where(x => x.Active);
            return all.ToList();
        }

        public Currency GetCurrencyById(long id)
        {
            return _currencyRepository.GetAll().FirstOrDefault(x => x.Id == id);
        }

        public IList<Currency> GetAllTestCurrencies(bool activeOnly)
        {
            var all = _currencyRepository.GetAll()
                .Where(x => x.IsTest);
            if (activeOnly) all = all.Where(x => x.Active);
            return all.ToList();
        }

        public IList<Currency> GetAllLiveCurrencies(bool activeOnly)
        {
            var all = _currencyRepository.GetAll()
                .Where(x => !x.IsTest);
            if (activeOnly) all = all.Where(x => x.Active);
            return all.ToList();
        }

        public Currency GetLiveCurrency()
        {
            return _currencyRepository.GetAll()
                .Where(x => !x.IsTest && x.Active)
                .OrderByDescending(x => x.Timestamp)
                .FirstOrDefault();
        }

        public Currency GetTestCurrency()
        {
            return _currencyRepository.GetAll()
                .Where(x => x.IsTest && x.Active)
                .OrderByDescending(x => x.Timestamp)
                .FirstOrDefault();
        }
    }
}
