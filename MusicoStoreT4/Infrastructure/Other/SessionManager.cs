using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;

namespace Infrastructure.Other
{
    public class SessionManager : ISessionManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public T? Get<T>(string key)
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            var value = session?.GetString(key);

            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }

        public void Set<T>(string key, T value)
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            var serializedValue = JsonSerializer.Serialize(value);
            session?.SetString(key, serializedValue);
        }

        public void Remove(string key)
        {
            _httpContextAccessor.HttpContext?.Session.Remove(key);
        }
    }
}
