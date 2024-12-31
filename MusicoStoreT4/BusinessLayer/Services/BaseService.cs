using BusinessLayer.Services.Interfaces;
using Infrastructure.UnitOfWork;

namespace BusinessLayer.Services
{
    public class BaseService : IBaseService
    {
        private readonly IUnitOfWork uow;

        public BaseService(IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }

        public async Task SaveAsync(bool save)
        {
            if (save)
            {
                await uow.SaveAsync();
            }
        }
    }
}
