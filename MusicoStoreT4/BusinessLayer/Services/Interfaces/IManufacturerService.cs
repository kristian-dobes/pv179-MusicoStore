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
        Task<IEnumerable<ManufacturerSummaryDTO>> GetManufacturersAsync();
        Task<ManufacturerSummaryDTO?> GetById(int id);
        Task<IEnumerable<ManufacturerDTO>> GetManufacturersWithProductsAsync();
        Task<bool> ValidateManufacturerAsync(int manufacturerId);
        Task<bool> DeleteManufacturerAsync(int manufacturerId);
        Task CreateManufacturerAsync(ManufacturerUpdateDTO manufacturerDto);
        Task<ManufacturerDTO?> UpdateManufacturerAsync(int id, ManufacturerUpdateDTO updateManufacturerDto);
    }
}
