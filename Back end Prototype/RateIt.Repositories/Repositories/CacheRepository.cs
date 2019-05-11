using RateIt.Repositories.Interfaces;
using RateIt.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class CacheRepository : ICacheRepository
    {
        public bool CacheItem<T>(string key, T value)
        {
            return RedisUtility.Save<T>(key, value);
        }

        public T GetItemFromCache<T>(string key)
        {
            return RedisUtility.Get<T>(key);
        }

        public bool DropCacheWhereKeyEquals(string key)
        {
            return RedisUtility.DropCacheWhereKeyEquals(key);
        }

        public bool DropItemFromCacheStartingWith(string key)
        {
            return RedisUtility.DropCacheStartingWith(key);
        }

        public bool DropItemFromCacheNotStartingWith(string key)
        {
            return RedisUtility.DropCacheDoesntStartWith(key);
        }

        public long GetTotalMemoryUsed()
        {
            return RedisUtility.GetTotalMemoryUsed();
        }

        public int GetCacheKeyCountStartingWith(string key)
        {
            return RedisUtility.GetCacheKeyCountStartingWith(key);
        }

        public int GetCacheKeyCountNotStartingWith(string key)
        {
            return RedisUtility.GetCacheKeyCountNotStartingWith(key);
        }
    }
}
