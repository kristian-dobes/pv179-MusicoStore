using BusinessLayer.DTOs.Category;
using BusinessLayer.DTOs.Manufacturer;

namespace WebMVC.Models.Product
{
    public class ProductUpdateViewModel
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required int QuantityInStock { get; set; }
        public required int PrimaryCategoryId { get; set; }
        public required int ManufacturerId { get; set; }
        public IEnumerable<int> SecondaryCategoryIds { get; set; } = new List<int>();

        public IEnumerable<CategorySummaryDTO> Categories { get; set; } = [];
        public IEnumerable<ManufacturerSummaryDTO> Manufacturers { get; set; } = [];
    }   
}
