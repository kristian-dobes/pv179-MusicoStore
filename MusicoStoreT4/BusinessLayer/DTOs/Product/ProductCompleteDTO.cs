using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Category;

namespace BusinessLayer.DTOs.Product
{
    public class ProductCompleteDTO
    {
        public int ProductId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required int QuantityInStock { get; set; }
        public required int LastModifiedById { get; set; }
        public required int EditCount { get; set; }
        public required int PrimaryCategoryId { get; set; }
        public required string PrimaryCategoryName { get; set; }
        public IEnumerable<CategoryBasicDto> SecondaryCategories { get; set; }
        public required int NumberOfSecondaryCategories { get; set; }
        public required int ManufacturerId { get; set; }
        public required string ManufacturerName { get; set; }
        public string? ImageFilePath { get; set; }
    }
}
