using ECommerce.Common.Caching.Abstract;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ECommerce.Common.Caching.Concrete.Redis
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;

        public RedisCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public void Add(string key, object data, double duration)
        {
            var serializedItems = JsonConvert.SerializeObject(data);
            var byteItems = Encoding.UTF8.GetBytes(serializedItems);

            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(duration), //Cache süresi
                //AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(5), // Redis’de ilgili keye ait cache’in mutlaka yani işlem yapılsın ya da yapılmasın 5sn sonunda düşeceğinin belirlenmesidir.
                //SlidingExpiration = TimeSpan.FromSeconds(10) //Redis’de ilgili key ile belli bir zaman mesela bu örnekte 5sn içinde hiçbir işlem yapılmaz ise, cache’in düşeceğinin belirlenmesidir.
            };

            _distributedCache.Set(key, byteItems, options);
        }

        public async Task AddAsync(string key, object data, double duration)
        {
            var serializedItems = JsonConvert.SerializeObject(data);
            var byteItems = Encoding.UTF8.GetBytes(serializedItems);

            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(duration), //Cache süresi
                //AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(5), // Redis’de ilgili keye ait cache’in mutlaka yani işlem yapılsın ya da yapılmasın 5sn sonunda düşeceğinin belirlenmesidir.
                //SlidingExpiration = TimeSpan.FromSeconds(10) //Redis’de ilgili key ile belli bir zaman mesela bu örnekte 5sn içinde hiçbir işlem yapılmaz ise, cache’in düşeceğinin belirlenmesidir.
            };

            await _distributedCache.SetAsync(key, byteItems, options);
        }

        public T Get<T>(string key)
        {
            var getCacheResponse = _distributedCache.Get(key);
            if (getCacheResponse != null)
            {
                var objectString = Encoding.UTF8.GetString(getCacheResponse);
                return JsonConvert.DeserializeObject<T>(objectString);
            }

            return default;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var getCacheResponse = await _distributedCache.GetAsync(key);
            if (getCacheResponse != null)
            {
                var objectString = Encoding.UTF8.GetString(getCacheResponse);
                return JsonConvert.DeserializeObject<T>(objectString);
            }

            return default;
        }

        public object Get(string key)
        {
            var getCacheResponse = _distributedCache.Get(key);
            if (getCacheResponse != null)
            {
                var objectString = Encoding.UTF8.GetString(getCacheResponse);
                return JsonConvert.DeserializeObject<object>(objectString);
            }

            return null;
        }

        public async Task<object> GetAsync(string key)
        {
            var getCacheResponse = await _distributedCache.GetAsync(key);
            if (getCacheResponse != null)
            {
                var objectString = Encoding.UTF8.GetString(getCacheResponse);
                return JsonConvert.DeserializeObject<object>(objectString);
            }

            return null;
        }

        public bool IsExists(string key)
        {
            return _distributedCache.Get(key) != null ? true : false;
        }

        public async Task<bool> IsExistsAsync(string key)
        {
            return await _distributedCache.GetAsync(key) != null ? true : false;
        }

        public void Remove(string key)
        {
            _distributedCache.Remove(key);
        }

        public async Task RemoveAsync(string key)
        {
            await _distributedCache.RemoveAsync(key);
        }
    }
}
