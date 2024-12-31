using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOs.Product
{
    public class ProductUpdateDTO 
    {
        [MinLength(1)]
        [MaxLength(100)]
        public required string Name { get; set; }
        [MinLength(1)]
        [MaxLength(255)]
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required int QuantityInStock { get; set; }
        public required int LastModifiedById { get; set; }
        public required int PrimaryCategoryId { get; set; }
        public required IEnumerable<int> SecondaryCategoryIds { get; set; }
        public required int ManufacturerId { get; set; }
    }
}
