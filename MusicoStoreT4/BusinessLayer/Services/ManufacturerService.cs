using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Cache;
using BusinessLayer.Cache.Interfaces;
using BusinessLayer.DTOs;
using BusinessLayer.DTOs.Category;
using BusinessLayer.DTOs.Manufacturer;
using BusinessLayer.DTOs.Product;
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
        private readonly IMemoryCacheWrapper _cacheWrapper;
        private const string MANUFACTURER_LIST_CACHE_KEY = "Manufacturers_List";
        private static readonly CacheOptions CacheOptions =
            new(
                AbsoluteExpiration: TimeSpan.FromHours(12),
                SlidingExpiration: TimeSpan.FromMinutes(30)
            );

        public ManufacturerService(IUnitOfWork unitOfWork, IMemoryCacheWrapper memoryCacheWrapper)
            : base(unitOfWork)
        {
            _uow = unitOfWork;
            _cacheWrapper = memoryCacheWrapper;
        }

        public async Task<IEnumerable<ManufacturerSummaryDTO>> GetManufacturersAsync()
        {
            return await _cacheWrapper.GetOrCreateAsync(
                MANUFACTURER_LIST_CACHE_KEY,
                async () =>
                    await _uow
                        .ManufacturersRep.GetAllQueryWithProducts()
                        .Select(m => new ManufacturerSummaryDTO
                        {
                            ManufacturerId = m.Id,
                            Name = m.Name,
                            ProductCount = m.Products != null ? m.Products.Count : 0
                        })
                        .ToListAsync(),
                CacheOptions
            );
        }

        public async Task<ManufacturerSummaryDTO?> GetById(int id)
        {
            return await _uow
                .ManufacturersRep.GetQueryById(id)
                .Select(m => new ManufacturerSummaryDTO
                {
                    ManufacturerId = m.Id,
                    Name = m.Name,
                    ProductCount = m.Products != null ? m.Products.Count : 0
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ManufacturerDTO>> GetManufacturersWithProductsAsync()
        {
            var manufacturers = await _uow.ManufacturersRep.GetManufacturersWithProductsAsync();
            return manufacturers.Select(m => m.Adapt<ManufacturerDTO>()).ToList();
        }

        public async Task<ManufacturerProductsDTO?> GetManufacturerWithProductsAsync(
            int manufacturerId
        )
        {
            return await _uow
                .ManufacturersRep.GetQueryById(manufacturerId)
                .Select(m => new ManufacturerProductsDTO
                {
                    ManufacturerId = m.Id,
                    Name = m.Name,
                    ProductCount = m.Products != null ? m.Products.Count : 0,
                    Products = m
                        .Products.Select(p => new ProductSummaryDTO
                        {
                            ProductId = p.Id,
                            Name = p.Name,
                            Description = p.Description,
                            Price = p.Price,
                            QuantityInStock = p.QuantityInStock
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> ValidateManufacturerAsync(int manufacturerId)
        {
            return await _uow.ManufacturersRep.AnyAsync(m => m.Id == manufacturerId);
        }

        public async Task<bool> DeleteManufacturerAsync(int manufacturerId)
        {
            var manufacturer = (
                await _uow.ManufacturersRep.GetManufacturersWithProductsAsync()
            ).FirstOrDefault(m => m.Id == manufacturerId);

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
            _cacheWrapper.Invalidate(MANUFACTURER_LIST_CACHE_KEY);

            return true;
        }

        public async Task CreateManufacturerAsync(ManufacturerUpdateDTO manufacturerDto)
        {
            if (string.IsNullOrWhiteSpace(manufacturerDto.Name))
            {
                throw new ArgumentException("Manufacturer name is required");
            }

            var exists = (
                await _uow.ManufacturersRep.WhereAsync(m => m.Name == manufacturerDto.Name)
            ).Any();

            if (exists)
            {
                throw new ArgumentException("Manufacturer already exists");
            }

            var manufacturer = manufacturerDto.Adapt<Manufacturer>();

            await _uow.ManufacturersRep.AddAsync(manufacturer);
            _cacheWrapper.Invalidate(MANUFACTURER_LIST_CACHE_KEY);
        }

        public async Task<ManufacturerDTO?> UpdateManufacturerAsync(
            int id,
            ManufacturerUpdateDTO updateManufacturerDto
        )
        {
            if (string.IsNullOrWhiteSpace(updateManufacturerDto.Name))
            {
                throw new ArgumentException("Manufacturer name is required");
            }

            var existingManufacturer = (
                await _uow.ManufacturersRep.WhereAsync(m => m.Id == id)
            ).FirstOrDefault();

            if (existingManufacturer == null)
            {
                throw new KeyNotFoundException("Manufacturer ID not found");
            }

            var nameExists = (
                await _uow.ManufacturersRep.WhereAsync(m =>
                    m.Name == updateManufacturerDto.Name && m.Id != id
                )
            ).Any();

            if (nameExists)
            {
                throw new ArgumentException("Manufacturer with that name already exists");
            }

            existingManufacturer.Name = updateManufacturerDto.Name;

            await _uow.SaveAsync();
            _cacheWrapper.Invalidate(MANUFACTURER_LIST_CACHE_KEY);

            return existingManufacturer.Adapt<ManufacturerDTO>();
        }
    }
}
