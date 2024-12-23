using BusinessLayer.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface IOrderService
    {
        Task<ICollection<OrderDetailDTO>> GetOrders();
        Task<OrderDetailDTO?> GetOrderByIdAsync(int id);
        //Task<ManufacturerDTO> CreateManufacturerAsync(ManufacturerNameDTO manufacturer);
        //Task<ManufacturerDTO?> UpdateManufacturerAsync(int id, ManufacturerNameDTO manufacturerDto);
        ////public Task<ManufacturerDto> ValidateManufacturerAsync(int manufacturerId);
        //public Task<bool> ValidateManufacturerAsync(int manufacturerId);
        //public Task DeleteManufacturerAsync(int manufacturerId);
    }
}
