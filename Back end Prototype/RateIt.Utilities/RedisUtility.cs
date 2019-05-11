using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace RateIt.Utilities
{
    public static class RedisUtility
    {
        public static long CurrentLimit = 30000000;

        public static bool Save<T>(string key, T value)
        {
            try
            {
                bool isSuccess = false;
                var pass = ConfigReader.GetInstance().RedisPass;
                var host = ConfigReader.GetInstance().RedisHost;
                using (RedisClient redisClient = new RedisClient(host, 10840,
                    pass))
                {
                    if (value != null)
                    {
                        JavaScriptSerializer s = new JavaScriptSerializer();
                        var serializedValue = s.Serialize(value);
                        isSuccess = redisClient.Set(key, serializedValue);
                    }
                }
                return isSuccess;
            }
            catch
            {
                return false;
            }
        }

        public static T Get<T>(string key)
        {
            try
            {
                var pass = ConfigReader.GetInstance().RedisPass;
                var host = ConfigReader.GetInstance().RedisHost;
                using (RedisClient redisClient = new RedisClient(host, 10840,
                    pass))
                {
                    var item = redisClient.Get<string>(key);
                    if (!string.IsNullOrEmpty(item))
                    {
                        JavaScriptSerializer s = new JavaScriptSerializer();
                        return s.Deserialize<T>(item);
                    }
                    return default(T);
                }
            }
            catch
            {
                return default(T);
            }
        }

        //Flush all
        public static void DropCache(string host)
        {
            try
            {
                using (RedisClient redisClient = new RedisClient(host))
                {
                    redisClient.FlushAll();
                }
            }
            catch
            {}
        }

        public static bool DropCacheStartingWith(string startingText)
        {
            try
            {
                var pass = ConfigReader.GetInstance().RedisPass;
                var host = ConfigReader.GetInstance().RedisHost;
                using (RedisClient redisClient = new RedisClient(host, 10840,
                    pass))
                {
                    var keys = redisClient.GetAllKeys();
                    var subset = keys.Where(x => x.StartsWith(startingText));
                    redisClient.RemoveAll(subset);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool DropCacheWhereKeyEquals(string key)
        {
            try
            {
                var pass = ConfigReader.GetInstance().RedisPass;
                var host = ConfigReader.GetInstance().RedisHost;
                using (RedisClient redisClient = new RedisClient(host, 10840,
                    pass))
                {
                    redisClient.Remove(key);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static int GetCacheKeyCountStartingWith(string value)
        {
            try
            {
                return GetAllKeys().Where(x => x.StartsWith(value))?.Count() ?? 0;
            }
            catch
            {
                return -1;
            }
        }

        public static int GetCacheKeyCountNotStartingWith(string value)
        {
            try
            {
                return GetAllKeys().Where(x => !x.StartsWith(value))?.Count() ?? 0;
            }
            catch
            {
                return -1;
            }
        }

        public static bool DropCacheDoesntStartWith(string startingText)
        {
            try
            {
                var pass = ConfigReader.GetInstance().RedisPass;
                var host = ConfigReader.GetInstance().RedisHost;
                using (RedisClient redisClient = new RedisClient(host, 10840,
                    pass))
                {
                    var keys = redisClient.GetAllKeys();
                    var subset = keys.Where(x => !x.StartsWith(startingText));
                    redisClient.RemoveAll(subset);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static long GetTotalMemoryUsed()
        {
            try
            {
                var pass = ConfigReader.GetInstance().RedisPass;
                var host = ConfigReader.GetInstance().RedisHost;
                var dbSize = (long)0;
                using (RedisClient redisClient = new RedisClient(host, 10840,
                        pass))
                {
                    var info = redisClient.Info;
                    if (info != null && info.Keys.Any() && info.Keys.Contains("used_memory"))
                        dbSize = long.Parse(info["used_memory"]);
                }
                return dbSize;
            }
            catch
            {
                return -1;
            }
        }

        public static IList<string> GetAllKeys()
        {
            try
            {
                var pass = ConfigReader.GetInstance().RedisPass;
                var host = ConfigReader.GetInstance().RedisHost;
                var keys = new List<string>();
                using (RedisClient redisClient = new RedisClient(host, 10840,
                        pass))
                {
                    keys = redisClient.GetAllKeys();
                }
                return keys;
            }
            catch
            {
                return null;
            }
        }
    }
}
