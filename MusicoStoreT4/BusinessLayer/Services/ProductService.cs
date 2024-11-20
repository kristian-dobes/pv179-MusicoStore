using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services
{
    public class ProductService : BaseService, IProductService 
    {
        private readonly MyDBContext _dBContext;

        public ProductService(MyDBContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task ReassignProductsToManufacturerAsync(int sourceManufacturerId, int targetManufacturerId)
        {
            // Fetch all products of the source manufacturer
            var productsToUpdate = await _dBContext.Products
                .Where(p => p.ManufacturerId == sourceManufacturerId)
                .ToListAsync();

            // Reassign each product's manufacturer
            foreach (var product in productsToUpdate)
            {
                product.ManufacturerId = targetManufacturerId;
            }

            // Save changes to the database
            await _dBContext.SaveChangesAsync();
        }
    }
}
