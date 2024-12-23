using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs;
using BusinessLayer.DTOs.Manufacturer;
using BusinessLayer.DTOs.Product;

namespace BusinessLayer.Services.Interfaces
{
    public interface IManufacturerService : IBaseService
    {
        //public Task<ManufacturerDto> ValidateManufacturerAsync(int manufacturerId);
        public Task<bool> ValidateManufacturerAsync(int manufacturerId);
        Task<List<ManufacturerDto>> GetManufacturersAsync();
        public Task<bool> DeleteManufacturerAsync(int manufacturerId);
        Task<List<ManufacturerDto>> GetManufacturersWithProductsAsync();
        Task CreateManufacturerAsync(string manufacturerName);
        Task<ManufacturerDto> UpdateManufacturerAsync(UpdateManufacturerDto updateManufacturerDto);
    }
}
