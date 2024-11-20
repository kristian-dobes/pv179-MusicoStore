using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
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

        public async Task<List<Product>> GetProductsByManufacturerAsync(int manufacturerId)
        {
            return await _dBContext.Products
                    .Where(p => p.ManufacturerId == manufacturerId)
                    .ToListAsync();
        }

        public async Task UpdateProductManufacturerAsync(int productId, int newManufacturerId)
        {
            var product = await _dBContext.Products
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found.");

            product.ManufacturerId = newManufacturerId;

            await _dBContext.SaveChangesAsync();
        }
    }
}
