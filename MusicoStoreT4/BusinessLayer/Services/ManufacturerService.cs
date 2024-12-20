using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs;
using BusinessLayer.Mapper;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services
{
    public class ManufacturerService : BaseService, IManufacturerService
    {
        private readonly MyDBContext _dBContext;

        public ManufacturerService(MyDBContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<bool> ValidateManufacturerAsync(int manufacturerId)
        {
            return await _dBContext.Manufacturers
                .AnyAsync(m => m.Id == manufacturerId);
        }

        public async Task DeleteManufacturerAsync(int manufacturerId)
        {
            var manufacturer = await _dBContext.Manufacturers
                .FirstOrDefaultAsync(m => m.Id == manufacturerId);

            if (manufacturer == null)
            {
                return;
            }

            _dBContext.Manufacturers.Remove(manufacturer);
            await _dBContext.SaveChangesAsync();
        }
    }
}
