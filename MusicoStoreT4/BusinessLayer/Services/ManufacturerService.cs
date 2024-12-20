using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs;
using BusinessLayer.DTOs.Manufacturer;
using BusinessLayer.Mapper;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Mapster;
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

        public async Task<ICollection<ManufacturerSummaryDTO>> GetManufacturers()
        {
            IQueryable<Manufacturer> manufacturerQuery = _dBContext.Manufacturers;
            
            // Fetch data into a list
            var manufacturers = await manufacturerQuery.ToListAsync();
            
            // Map to DTOs
            var manufacturerDTOs = manufacturers.Adapt<ICollection<ManufacturerSummaryDTO>>();
            
            return manufacturerDTOs;
        }

        public async Task<ManufacturerSummaryDTO?> GetManufacturerByIdAsync(int manufacturerId)
        {
            var manufacturer = await _dBContext.Manufacturers
                .SingleOrDefaultAsync(m => m.Id == manufacturerId);
           
            return manufacturer?.Adapt<ManufacturerSummaryDTO>();
        }

        public async Task<ManufacturerDTO> CreateManufacturerAsync(ManufacturerNameDTO manufacturer)
        {
            var manufacturerEntity = manufacturer.Adapt<Manufacturer>();
            
            _dBContext.Manufacturers.Add(manufacturerEntity);
            await SaveAsync(true);

            return manufacturerEntity.Adapt<ManufacturerDTO>();
        }

        public async Task<ManufacturerDTO?> UpdateManufacturerAsync(int manufacturerId, ManufacturerNameDTO manufacturerDto)
        {
            var manufacturer = await _dBContext.Manufacturers.FindAsync(manufacturerId);

            if (manufacturer == null)
            {
                return null;
            }

            manufacturer = manufacturerDto.Adapt(manufacturer);
            _dBContext.Manufacturers.Update(manufacturer);
            await SaveAsync(true);
            return manufacturer.Adapt<ManufacturerDTO>();
        }

        public async Task<bool> ValidateManufacturerAsync(int manufacturerId)
        {
            return await _dBContext.Manufacturers
                .AnyAsync(m => m.Id == manufacturerId);
        }

        public async Task DeleteManufacturerAsync(int manufacturerId)
        {
            var manufacturer = await _dBContext.Manufacturers
                .FindAsync(manufacturerId);

            if (manufacturer != null)
            {
                _dBContext.Manufacturers.Remove(manufacturer);
                await SaveAsync(true);
            }
        }
    }
}
