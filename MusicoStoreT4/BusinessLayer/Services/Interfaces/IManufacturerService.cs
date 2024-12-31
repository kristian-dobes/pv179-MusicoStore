using BusinessLayer.DTOs.Manufacturer;

namespace BusinessLayer.Services.Interfaces
{
    public interface IManufacturerService : IBaseService
    {
        Task<IEnumerable<ManufacturerSummaryDTO>> GetManufacturersAsync();
        Task<ManufacturerSummaryDTO?> GetById(int id);
        Task<IEnumerable<ManufacturerDTO>> GetManufacturersWithProductsAsync();
        Task<ManufacturerProductsDTO?> GetManufacturerWithProductsAsync(int manufacturerId);
        Task<bool> ValidateManufacturerAsync(int manufacturerId);
        Task<bool> DeleteManufacturerAsync(int manufacturerId);
        Task CreateManufacturerAsync(ManufacturerUpdateDTO manufacturerDto);
        Task<ManufacturerDTO?> UpdateManufacturerAsync(int id, ManufacturerUpdateDTO updateManufacturerDto);
    }
}
