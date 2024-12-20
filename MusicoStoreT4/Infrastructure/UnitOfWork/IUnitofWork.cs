using Infrastructure.Repository;
using Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        ICategoryRepository Categories { get; }
        IManufacturerRepository Manufacturers { get; }
        IOrderRepository Orders { get; }
        IOrderItemRepository OrderItems { get; }
        IProductRepository Products { get; }
        IProductImageRepository ProductImages { get; }
        IProductAuditRepository ProductAudits { get; }

        Task<int> SaveAsync();
        void BeginTransaction();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
