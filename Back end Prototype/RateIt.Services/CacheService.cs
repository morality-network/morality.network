using RateIt.Repositories.Interfaces;
using RateIt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services
{
    public class CacheService : ICacheService
    {
        private readonly ICacheRepository _cacheRepository;

        public CacheService(ICacheRepository cacheRepository)
        {
            _cacheRepository = cacheRepository;
        }

        public bool CacheItem<T>(string key, T value)
        {
            return _cacheRepository.CacheItem<T>(key, value);
        }

        public bool DropCacheWhereKeyEquals(string key)
        {
            return _cacheRepository.DropCacheWhereKeyEquals(key);
        }

        public bool DropItemFromCacheNotStartingWith(string key)
        {
            return _cacheRepository.DropItemFromCacheNotStartingWith(key);
        }

        public bool DropItemFromCacheStartingWith(string key)
        {
            return _cacheRepository.DropItemFromCacheStartingWith(key);
        }

        public int GetCacheKeyCountNotStartingWith(string key)
        {
            return _cacheRepository.GetCacheKeyCountNotStartingWith(key);
        }

        public int GetCacheKeyCountStartingWith(string key)
        {
            return _cacheRepository.GetCacheKeyCountStartingWith(key);
        }

        public T GetItemFromCache<T>(string key)
        {
            return _cacheRepository.GetItemFromCache<T>(key);
        }

        public long GetTotalMemoryUsed()
        {
            return _cacheRepository.GetTotalMemoryUsed();
        }
    }
}
