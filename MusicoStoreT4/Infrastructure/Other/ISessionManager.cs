namespace Infrastructure.Other
{
    public interface ISessionManager
    {
        T? Get<T>(string key);
        void Set<T>(string key, T value);
        void Remove(string key);
    }
}
