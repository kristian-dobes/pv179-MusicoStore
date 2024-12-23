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
        private readonly IUnitOfWork _uow;

        public ManufacturerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _uow = unitOfWork;
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

        public async Task<List<ManufacturerDto>> GetManufacturersAsync()
        {
            return (await _uow.ManufacturersRep.GetAllAsync()).Select(m => m.MapToManufacturerDTO()).ToList();
        }

        public async Task<List<ManufacturerDto>> GetManufacturersWithProductsAsync()
        {
            return (await _uow.ManufacturersRep.GetManufacturersWithProductsAsync()).Select(m => m.MapToManufacturerDTO()).ToList();
        }

        public async Task<bool> ValidateManufacturerAsync(int manufacturerId)
        {
            return await _uow.ManufacturersRep
                .AnyAsync(m => m.Id == manufacturerId);
        }

        public async Task<bool> DeleteManufacturerAsync(int manufacturerId)
        {
            var manufacturer = (await _uow.ManufacturersRep.WhereAsync(m => m.Id == manufacturerId)).FirstOrDefault();

            if (manufacturer == null)
            {
                return false;
            }

            await _uow.ManufacturersRep.DeleteAsync(manufacturer.Id);
            await _uow.SaveAsync();

            return true;
        }

        public async Task CreateManufacturerAsync(string manufacturerName)
        {
            if (string.IsNullOrWhiteSpace(manufacturerName))
            {
                throw new ArgumentException("Manufacturer name is required");
            }

            var exists = (await _uow.ManufacturersRep.WhereAsync(m => m.Name == manufacturerName)).Any();

            if (exists)
            {
                throw new ArgumentException("Manufacturer already exists");
            }

            var manufacturer = new Manufacturer
            {
                Name = manufacturerName,
            };

            await _uow.ManufacturersRep.AddAsync(manufacturer);
        }

        public async Task<ManufacturerDto> UpdateManufacturerAsync(UpdateManufacturerDto updateManufacturerDto)
        {
            if (string.IsNullOrWhiteSpace(updateManufacturerDto.Name))
            {
                throw new ArgumentException("Manufacturer name is required");
            }

            var existingManufacturer = (await _uow.ManufacturersRep
                .WhereAsync(m => m.Id == updateManufacturerDto.ManufacturerId)).FirstOrDefault();

            if (existingManufacturer == null)
            {
                throw new KeyNotFoundException("Manufacturer ID not found");
            }

            var nameExists = (await _uow.ManufacturersRep
                .WhereAsync(m => m.Name == updateManufacturerDto.Name && m.Id != updateManufacturerDto.ManufacturerId)).Any();

            if (nameExists)
            {
                throw new ArgumentException("Manufacturer with that name already exists");
            }

            existingManufacturer.Name = updateManufacturerDto.Name;

            await _uow.SaveAsync();

            return existingManufacturer.MapToManufacturerDTO();
        }
    }
}
