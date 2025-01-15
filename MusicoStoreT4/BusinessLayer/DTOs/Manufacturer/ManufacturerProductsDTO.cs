using BusinessLayer.DTOs.Product;

namespace BusinessLayer.DTOs.Manufacturer
{
    public class ManufacturerProductsDTO
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductSummaryDTO>? Products { get; set; } = [];
        public int ProductCount { get; set; }
    }
}
