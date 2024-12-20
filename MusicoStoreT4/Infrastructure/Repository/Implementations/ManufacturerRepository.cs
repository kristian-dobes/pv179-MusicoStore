using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly MyDBContext _context;

        public ManufacturerRepository(MyDBContext context)
        {
            _context = context;
        }

        public async Task<Manufacturer?> Add(Manufacturer entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Manufacturer added = (await _context.Manufacturers.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();

            return added;
        }

        public async Task<bool> Delete(int id)
        {
            var manufacturer = await _context.Manufacturers.FindAsync(id);

            if (manufacturer == null)
                return false;

            _context.Manufacturers.Remove(manufacturer);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Manufacturer>> GetAll()
        {
            return await _context.Manufacturers.ToListAsync();
        }

        public async Task<Manufacturer?> GetById(int id)
        {
            return await _context.Manufacturers.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> Update(Manufacturer entity)
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
    }
}
