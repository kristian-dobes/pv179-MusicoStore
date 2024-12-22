using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs;
using BusinessLayer.DTOs.Manufacturer;
using DataAccessLayer.Models;

namespace BusinessLayer.Services.Interfaces
{
    public interface IManufacturerService : IBaseService
    {
        public Task<bool> ValidateManufacturerAsync(int manufacturerId);
        Task<List<ManufacturerDto>> GetManufacturersAsync();
        public Task<bool> DeleteManufacturerAsync(int manufacturerId);
        Task<List<ManufacturerDto>> GetManufacturersWithProductsAsync();
        Task CreateManufacturerAsync(string manufacturerName);
        Task<ManufacturerDto> UpdateManufacturerAsync(UpdateManufacturerDto updateManufacturerDto);
    }
}
