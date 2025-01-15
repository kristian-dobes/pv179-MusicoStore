using BusinessLayer.DTOs.Category;
using BusinessLayer.DTOs.Manufacturer;
using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models.Product
{
    public class ProductCreateViewModel
    {
        [Required]
        public  string Name { get; set; }
        
        [Required]
        public  string Description { get; set; }
        
        [Required]
        public  decimal Price { get; set; }
        
        [Required]
        public  int QuantityInStock { get; set; }
        
        [Required]
        public  int PrimaryCategoryId { get; set; }

        public List<int>? SecondaryCategoryIds { get; set; } = [];

        [Required]
        public  int ManufacturerId { get; set; }

        public IEnumerable<CategorySummaryDTO> Categories { get; set; } = [];
        public IEnumerable<ManufacturerSummaryDTO> Manufacturers { get; set; } = [];
    }
}
