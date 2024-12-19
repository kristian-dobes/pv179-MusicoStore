using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public required string LastModifiedBy { get; set; }
        public required int CategoryId { get; set; }
        public required int ManufacturerId { get; set; }
    }
}
