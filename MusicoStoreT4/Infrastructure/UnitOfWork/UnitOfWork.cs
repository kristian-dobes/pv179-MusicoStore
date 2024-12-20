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

        public IProductRepository Products { get; }
        public ICategoryRepository Categories { get; }
        public IManufacturerRepository Manufacturers { get; }
        public IUserRepository Users { get; }
        public IOrderRepository Orders { get; }
        public IOrderItemRepository OrderItems { get; }
        public IProductAuditRepository ProductAudits { get; }
        public IProductImageRepository ProductImages { get; }

        public UnitOfWork(MyDBContext context,
                          IUserRepository userRepository,
                          ICategoryRepository categoryRepository,
                          IManufacturerRepository manufacturerRepository,
                          IOrderRepository orderRepository,
                          IOrderItemRepository orderItemRepository,
                          IProductRepository productRepository,
                          IProductImageRepository productImageRepository,
                          IProductAuditRepository productAuditRepository)
        {
            _context = context;

            Users = userRepository;
            Categories = categoryRepository;
            Manufacturers = manufacturerRepository;
            Orders = orderRepository;
            OrderItems = orderItemRepository;
            Products = productRepository;
            ProductImages = productImageRepository;
            ProductAudits = productAuditRepository;
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
