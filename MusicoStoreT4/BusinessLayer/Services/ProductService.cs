using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Product;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Mapster;
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

        public async Task<ICollection<ProductCompleteDTO>> GetProducts()
        {
            //IQueryable<Product> productQuerry = _dBContext.Products;
            //return (await productQuerry.ToListAsync()).Adapt<ICollection<ProductCompleteDTO>>();

            IQueryable<Product> productQuery = _dBContext.Products;

            // Fetch data into a list
            var products = await productQuery.ToListAsync();

            // Map to DTOs
            var productDTOs = products.Adapt<ICollection<ProductCompleteDTO>>();

            return productDTOs;
        }

        public async Task<ProductCompleteDTO?> GetProductByIdAsync(int productId)
        {
            var product = await _dBContext.Products.SingleOrDefaultAsync(a => a.Id == productId);

            return product?.Adapt<ProductCompleteDTO>();
        }

        public async Task<ProductCompleteDTO?> UpdateProductAsync(int id, ProductUpdateDTO productDto)
        {
            var product = await _dBContext.Products.FindAsync(id);

            if (product == null)
            {
                //throw new KeyNotFoundException($"Product with ID {id} not found.");
                return null;
            }

            product = productDto.Adapt(product);

            //product.Name = productDto.Name;
            //product.Description = productDto.Description;
            //product.Price = productDto.Price;
            //product.ManufacturerId = productDto.ManufacturerId;
            //product.CategoryId = productDto.CategoryId;
            //product.QuantityInStock = productDto.QuantityInStock;
            //product.LastModifiedBy = modifiedBy;
            product.EditCount++;

            _dBContext.Products.Update(product);
            await SaveAsync(true);

            return product.Adapt<ProductCompleteDTO>();
        }

        public async Task<Product> CreateProductAsync(Product model, string createdBy)
        {
            model.LastModifiedBy = createdBy;
            model.EditCount = 0;
            _dBContext.Products.Add(model);
            await _dBContext.SaveChangesAsync();

            return model;
        }

        public async Task<ProductCompleteDTO> CreateProductAsync(ProductCreateDTO productDto)
        {
            var product = productDto.Adapt<Product>();

            product.EditCount = 0;

            _dBContext.Products.Add(product);
            await SaveAsync(true);
           
            return product.Adapt<ProductCompleteDTO>();
        }

        public async Task ReassignProductsToManufacturerAsync(int sourceManufacturerId, int targetManufacturerId)
        {
            var productsToUpdate = await _dBContext.Products
                .Where(p => p.ManufacturerId == sourceManufacturerId)
                .ToListAsync();

            foreach (var product in productsToUpdate)
            {
                product.ManufacturerId = targetManufacturerId;
            }

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
            var product = await _dBContext.Products.FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found.");

            product.ManufacturerId = newManufacturerId;

            await _dBContext.SaveChangesAsync();
        }

        public async Task<List<TopSellingProductDto>> GetTopSellingProductsByCategoryAsync(DateTime startDate, DateTime endDate, int topN = 5)
        {
            var orderItems = await (from orderItem in _dBContext.OrderItems
                                    join product in _dBContext.Products on orderItem.ProductId equals product.Id
                                    join category in _dBContext.Categories on product.CategoryId equals category.Id
                                    where orderItem.Order.Date >= startDate && orderItem.Order.Date <= endDate
                                    select new
                                    {
                                        CategoryId = category.Id,
                                        CategoryName = category.Name,
                                        ProductId = product.Id,
                                        ProductName = product.Name,
                                        orderItem.Quantity,
                                        orderItem.Price
                                    }).ToListAsync();

            var query = orderItems
                .GroupBy(item => new { item.CategoryId, item.CategoryName })
                .Select(categoryGroup => new TopSellingProductDto
                {
                    CategoryId = categoryGroup.Key.CategoryId,
                    CategoryName = categoryGroup.Key.CategoryName,
                    Products = categoryGroup
                        .GroupBy(product => new { product.ProductId, product.ProductName })
                        .Select(productGroup => new ProductSalesDto
                        {
                            ProductId = productGroup.Key.ProductId,
                            ProductName = productGroup.Key.ProductName,
                            TotalUnitsSold = productGroup.Sum(x => x.Quantity),
                            Revenue = (decimal)productGroup.Sum(x => (double)(x.Quantity * x.Price)) // Cast to double
                        })
                        .OrderByDescending(p => p.TotalUnitsSold)
                        .Take(topN)
                        .ToList()
                }).ToList();

            return query;
        }

        public async Task DeleteProductAsync(int productId)
        {
            //TODO does this method need string deletedBy?

            var product = await _dBContext.Products.FindAsync(productId);

            if (product != null)
            {
                _dBContext.Products.Remove(product);
                await SaveAsync(true);
            }

            //if (product == null)
            //    throw new KeyNotFoundException($"Product with ID {productId} not found.");

            // Optionally log the delete action or use the deletedBy field for audit purposes
            // e.g., _auditLogService.LogAsync(productId, "Delete", deletedBy);
        }

        public async Task<Boolean> IsProductValidAsync(int productId) 
        {
            // TODO might shoudl be implemented in repository ?
            return await _dBContext.Products.AnyAsync(p => p.Id == productId);
        }
    }
}
