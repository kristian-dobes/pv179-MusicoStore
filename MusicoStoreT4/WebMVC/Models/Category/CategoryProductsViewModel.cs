using BusinessLayer.DTOs.Product;

namespace WebMVC.Models.Category
{
    public class CategoryProductsViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductSummaryDTO>? PrimaryProducts { get; set; } = [];
        public int PrimaryProductCount { get; set; }
        public IEnumerable<ProductSummaryDTO>? SecondaryProducts { get; set; } = [];
        public int SecondaryProductCount { get; set; }
    }
}
