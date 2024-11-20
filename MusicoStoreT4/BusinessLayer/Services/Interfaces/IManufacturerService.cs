using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs;

namespace BusinessLayer.Services.Interfaces
{
    public interface IManufacturerService : IBaseService
    {
        //public Task<ManufacturerDto> ValidateManufacturerAsync(int manufacturerId);
        public Task<bool> ValidateManufacturerAsync(int manufacturerId);

        public Task DeleteManufacturerAsync(int manufacturerId);
    }
}
