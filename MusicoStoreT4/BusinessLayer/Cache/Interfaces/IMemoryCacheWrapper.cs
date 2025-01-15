namespace BusinessLayer.Cache.Interfaces
{
    public interface IMemoryCacheWrapper
    {
        Task<T> GetOrCreateAsync<T>(string cacheKey, Func<Task<T>> factory, CacheOptions options);
        void Invalidate(string cacheKey);
    }
}
