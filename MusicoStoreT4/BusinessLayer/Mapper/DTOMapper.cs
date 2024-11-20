using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs;
using BusinessLayer.DTOs.Product;
using DataAccessLayer.Models;

namespace BusinessLayer.Mapper
{
    public static class DTOMapper
    {
        public static CategoryDto MapToCategoryDTO(this Category category)
        {
            return new CategoryDto
            {
                CategoryId = category.Id,
                Name = category.Name,
                Products = category.Products?.Select(p => MapToProductDTO(p)).ToList()
            };
        }

        public static CategorySummaryDto MapToCategorySummaryDTO(this Category category)
        {
            return new CategorySummaryDto
            {
                CategoryId = category.Id,
                Name = category.Name,
                ProductCount = category.Products?.Count() ?? 0
            };
        }

        public static ManufacturerDto MapToManufacturerDTO(this Manufacturer manufacturer)
        {
            return new ManufacturerDto
            {
                ManufacturerId = manufacturer.Id,
                Name = manufacturer.Name,
                Products = manufacturer.Products?.Select(p => MapToProductDTO(p)).ToList()
            };
        }

        public static ProductDto MapToProductDTO(this Product product)
        {
            return new ProductDto
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryName = product.Category?.Name,
                ManufacturerName = product.Manufacturer?.Name
            };
        }
    }
}
