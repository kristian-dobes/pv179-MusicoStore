using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Implementations
{
    public class ManufacturerRepository : Repository<Manufacturer>, IManufacturerRepository
    {
        private readonly MyDBContext _context;

        public ManufacturerRepository(MyDBContext context)
            : base(context)
        {
            _context = context;
        }

        public override async Task<bool> UpdateAsync(Manufacturer entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var existingManufacturer = await _context.Manufacturers.FindAsync(entity.Id);

            if (existingManufacturer == null)
                return false;

            existingManufacturer.Name = entity.Name;

            _context.Manufacturers.Update(existingManufacturer);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Manufacturer>> GetManufacturersWithProductsAsync()
        {
            return await _context.Manufacturers.Include(m => m.Products).ToListAsync();
        }

        public IQueryable<Manufacturer> GetAllQuery()
        {
            return _context.Manufacturers.AsQueryable();
        }

        public IQueryable<Manufacturer> GetAllQueryWithProducts()
        {
            return _context.Manufacturers.Include(m => m.Products);
        }

        public IQueryable<Manufacturer> GetQueryById(int id)
        {
            return _context.Manufacturers
                .Where(m => m.Id == id)
                .Include(m => m.Products);
        }
    }
}
