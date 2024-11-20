using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs;

namespace BusinessLayer.Services.Interfaces
{
    public interface IProductService : IBaseService
    {
        public Task ReassignProductsToManufacturerAsync(int sourceManufacturerId, int targetManufacturerId);
    }
}
