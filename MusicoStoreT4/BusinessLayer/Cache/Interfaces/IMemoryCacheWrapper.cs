using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Cache.Interfaces
{
    public interface IMemoryCacheWrapper
    {
        Task<T> GetOrCreateAsync<T>(string cacheKey, Func<Task<T>> factory, CacheOptions options);
        void Invalidate(string cacheKey);
    }
}
