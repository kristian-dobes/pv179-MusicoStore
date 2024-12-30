using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Other
{
    public interface ISessionManager
    {
        T? Get<T>(string key);
        void Set<T>(string key, T value);
        void Remove(string key);
    }
}
