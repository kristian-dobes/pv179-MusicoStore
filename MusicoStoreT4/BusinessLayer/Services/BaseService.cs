using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;

namespace BusinessLayer.Services
{
    public class BaseService : IBaseService
    {
        private readonly MyDBContext _dBContext;

        public BaseService(MyDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task SaveAsync(bool save)
        {
            if (save)
            {
                await _dBContext.SaveChangesAsync();
            }
        }
    }
}
