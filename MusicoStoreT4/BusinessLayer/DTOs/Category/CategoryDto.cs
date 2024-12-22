using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Product;

namespace BusinessLayer.DTOs.Category
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<ProductDto>? Products { get; set; }
    }
}
