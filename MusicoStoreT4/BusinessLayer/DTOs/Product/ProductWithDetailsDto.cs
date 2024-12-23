using BusinessLayer.DTOs.Category;
using BusinessLayer.DTOs.Manufacturer;
using BusinessLayer.DTOs.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<OrderItemDto> OrderItems { get; set; }
        public CategoryDto Category { get; set; }
        public ManufacturerDto Manufacturer { get; set; }
    }
}
