using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface ICacheService
    {
        bool CacheItem<T>(string key, T value);
        T GetItemFromCache<T>(string key);
        bool DropCacheWhereKeyEquals(string key);
        bool DropItemFromCacheStartingWith(string key);
        bool DropItemFromCacheNotStartingWith(string key);
        long GetTotalMemoryUsed();
        int GetCacheKeyCountStartingWith(string key);
        int GetCacheKeyCountNotStartingWith(string key);
    }
}
