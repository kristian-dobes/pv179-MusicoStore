using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs;
using BusinessLayer.DTOs.Category;
using BusinessLayer.DTOs.Manufacturer;
using BusinessLayer.Mapper;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.UnitOfWork;
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

        public async Task<IEnumerable<ManufacturerSummaryDTO>> GetManufacturersAsync()
        {
            var manufacturers = await _uow.ManufacturersRep.GetAllAsync();
            return manufacturers.Select(m => m.Adapt<ManufacturerSummaryDTO>()).ToList();
        }
        public async Task<ManufacturerSummaryDTO?> GetById(int id)
        {
            var manufacturer = await _uow.ManufacturersRep.GetByIdAsync(id);

            return manufacturer.Adapt<ManufacturerSummaryDTO>();
        }

        public async Task<IEnumerable<ManufacturerDTO>> GetManufacturersWithProductsAsync()
        {
            var manufacturers = await _uow.ManufacturersRep.GetManufacturersWithProductsAsync();
            return manufacturers.Select(m => m.Adapt<ManufacturerDTO>()).ToList();
        }

        public async Task<bool> ValidateManufacturerAsync(int manufacturerId)
        {
            return await _uow.ManufacturersRep
                .AnyAsync(m => m.Id == manufacturerId);
        }

        public async Task<bool> DeleteManufacturerAsync(int manufacturerId)
        {
            var manufacturer = (await _uow.ManufacturersRep.GetManufacturersWithProductsAsync()).FirstOrDefault(m => m.Id == manufacturerId);

            if (manufacturer == null)
            {
                return false;
            }

            if (manufacturer.Products != null && manufacturer.Products.Any())
            {
                return false;
            }

            await _uow.ManufacturersRep.DeleteAsync(manufacturer.Id);
            await _uow.SaveAsync();

            return true;
        }

        public async Task CreateManufacturerAsync(ManufacturerUpdateDTO manufacturerDto)
        {
            if (string.IsNullOrWhiteSpace(manufacturerDto.Name))
            {
                throw new ArgumentException("Manufacturer name is required");
            }

            var exists = (await _uow.ManufacturersRep.WhereAsync(m => m.Name == manufacturerDto.Name)).Any();

            if (exists)
            {
                throw new ArgumentException("Manufacturer already exists");
            }

            var manufacturer = manufacturerDto.Adapt<Manufacturer>();

            await _uow.ManufacturersRep.AddAsync(manufacturer);
        }

        public async Task<ManufacturerDTO?> UpdateManufacturerAsync(int id, ManufacturerUpdateDTO updateManufacturerDto)
        {
            if (string.IsNullOrWhiteSpace(updateManufacturerDto.Name))
            {
                throw new ArgumentException("Manufacturer name is required.");
            }

            var existingManufacturer = await _uow.ManufacturersRep.GetByIdAsync(id);

            if (existingManufacturer == null)
            {
                throw new KeyNotFoundException("Manufacturer ID not found.");
            }

            if (await _uow.ManufacturersRep.AnyAsync(m => m.Name == updateManufacturerDto.Name && m.Id != id))
            {
                throw new ArgumentException("Manufacturer with that name already exists.");
            }

            existingManufacturer.Name = updateManufacturerDto.Name;

            await _uow.SaveAsync();

            return existingManufacturer.Adapt<ManufacturerDTO>();
        }
    }
}
