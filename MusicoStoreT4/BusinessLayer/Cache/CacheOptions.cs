namespace BusinessLayer.Cache
{
    public record CacheOptions(
        TimeSpan? AbsoluteExpiration = null,
        TimeSpan? SlidingExpiration = null
    );
}
