using BusinessLayer.Cache.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace BusinessLayer.Cache
{
    public class MemoryCacheWrapper : IMemoryCacheWrapper
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheWrapper(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<T> GetOrCreateAsync<T>(
            string cacheKey,
            Func<Task<T>> factory,
            CacheOptions options
        )
        {
            if (_memoryCache.TryGetValue(cacheKey, out T? cachedValue))
            {
                return cachedValue!;
            }

            // Generate the value
            var value = await factory();

            // Cache the value with the specified options
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = options.AbsoluteExpiration,
                SlidingExpiration = options.SlidingExpiration
            };

            _memoryCache.Set(cacheKey, value, cacheEntryOptions);
            return value;
        }

        public void Invalidate(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
        }
    }
}
