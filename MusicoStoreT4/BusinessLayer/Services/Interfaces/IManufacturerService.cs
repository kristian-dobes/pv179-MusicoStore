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
        Task<ICollection<ManufacturerSummaryDTO>> GetManufacturers();
        Task<ManufacturerSummaryDTO?> GetManufacturerByIdAsync(int id);
        Task<ManufacturerDTO> CreateManufacturerAsync(ManufacturerNameDTO manufacturer);
        Task<ManufacturerDTO?> UpdateManufacturerAsync(int id, ManufacturerNameDTO manufacturerDto);
        //public Task<ManufacturerDto> ValidateManufacturerAsync(int manufacturerId);
        public Task<bool> ValidateManufacturerAsync(int manufacturerId);
        public Task DeleteManufacturerAsync(int manufacturerId);
    }
}
