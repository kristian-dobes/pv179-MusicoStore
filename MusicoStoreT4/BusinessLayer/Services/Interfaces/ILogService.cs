using DataAccessLayer.Models.Enums;

namespace BusinessLayer.Services.Interfaces
{
    public interface ILogService : IBaseService
    {
        Task LogRequestAsync(string method, string path, RequestSource source);
    }
}
