using BusinessLayer.DTOs.Category;
using BusinessLayer.DTOs.Manufacturer;

namespace WebMVC.Models.Product
{
    public class ProductDetailViewModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required int QuantityInStock { get; set; }
        public required int LastModifiedById { get; set; }
        public required int EditCount { get; set; }
        public required CategorySummaryDTO Category { get; set; }
        public required ManufacturerSummaryDTO Manufacturer { get; set; }
    }
}
