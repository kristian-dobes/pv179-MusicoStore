using BusinessLayer.DTOs.Product;

namespace BusinessLayer.DTOs.Category
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public IEnumerable<ProductDto>? PrimaryProducts { get; set; }
        public IEnumerable<ProductDto>? SecondaryProducts { get; set; }
    }
}
