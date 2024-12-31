using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOs.Product
{
    // This class is used to create a new product from Admin panel
    public class ProductCreateDTO
    {
        [MinLength(1)]
        [MaxLength(100)]
        public required string Name { get; set; }

        [MinLength(10)]
        [MaxLength(255)]
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required int QuantityInStock { get; set; }
        public required int LastModifiedById { get; set; }
        public required int PrimaryCategoryId { get; set; }
        public required List<int> SecondaryCategoryIds { get; set; }
        public required int ManufacturerId { get; set; }
    }
}
