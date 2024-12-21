using DataAccessLayer.Data;
using Infrastructure.Repository;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDBContext _context;
        private IDbContextTransaction? _transaction;

        public IProductRepository ProductsRep { get; }
        public ICategoryRepository CategoriesRep { get; }
        public IManufacturerRepository ManufacturersRep { get; }
        public IUserRepository UsersRep { get; }
        public IOrderRepository OrdersRep { get; }
        public IOrderItemRepository OrderItemsRep { get; }
        public IAuditLogRepository ProductAuditsRep { get; }
        public IProductImageRepository ProductImagesRep { get; }
        public ILogRepository LogsRep { get; }

        public UnitOfWork(MyDBContext context,
                          IUserRepository userRepository,
                          ICategoryRepository categoryRepository,
                          IManufacturerRepository manufacturerRepository,
                          IOrderRepository orderRepository,
                          IOrderItemRepository orderItemRepository,
                          IProductRepository productRepository,
                          IProductImageRepository productImageRepository,
                          IAuditLogRepository auditLogRepository,
                          ILogRepository logsRepository)
        {
            _context = context;

            UsersRep = userRepository;
            CategoriesRep = categoryRepository;
            ManufacturersRep = manufacturerRepository;
            OrdersRep = orderRepository;
            OrderItemsRep = orderItemRepository;
            ProductsRep = productRepository;
            ProductImagesRep = productImageRepository;
            ProductAuditsRep = auditLogRepository;
            LogsRep = logsRepository;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}
