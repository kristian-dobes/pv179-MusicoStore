using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface ILogService : IBaseService
    {
        Task LogRequestAsync(string method, string path);
    }
}
