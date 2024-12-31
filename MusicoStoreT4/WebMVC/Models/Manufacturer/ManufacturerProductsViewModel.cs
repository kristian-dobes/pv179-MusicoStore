using BusinessLayer.DTOs.Product;

namespace WebMVC.Models.Manufacturer
{
    public class ManufacturerProductsViewModel
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductSummaryDTO>? Products { get; set; } = [];
        public int ProductCount { get; set; }
    }
}
