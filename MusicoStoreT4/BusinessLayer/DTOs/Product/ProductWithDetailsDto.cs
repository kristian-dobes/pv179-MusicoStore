using BusinessLayer.DTOs.Category;
using BusinessLayer.DTOs.Manufacturer;
using BusinessLayer.DTOs.OrderItem;

namespace BusinessLayer.DTOs.Product
{
    public class ProductWithDetailsDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime ProductDateOfCreation { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantityInStock { get; set; }
        public int ProductManufacturer { get; set; }
        public int ProductCategory { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
        public CategorySummaryDTO Category { get; set; }
        public ManufacturerSummaryDTO Manufacturer { get; set; }
    }
}
