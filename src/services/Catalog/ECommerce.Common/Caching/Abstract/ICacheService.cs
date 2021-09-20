using System.Threading.Tasks;

namespace ECommerce.Common.Caching.Abstract
{
    public interface ICacheService
    {
        T Get<T>(string key);

        Task<T> GetAsync<T>(string key);

        object Get(string key);

        Task<object> GetAsync(string key);

        void Add(string key, object data, double duration);

        Task AddAsync(string key, object data, double duration);

        bool IsExists(string key);

        Task<bool> IsExistsAsync(string key);

        void Remove(string key);

        Task RemoveAsync(string key);
    }
}
