using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Product;

namespace BusinessLayer.DTOs.Category
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
<<<<<<<< HEAD:MusicoStoreT4/BusinessLayer/DTOs/Category/CategoryDto.cs
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<ProductDto>? Products { get; set; }
========
        public required string Name { get; set; }
        public IEnumerable<ProductDto>? Products { get; set; }
>>>>>>>> feature/admin-endpoints:MusicoStoreT4/BusinessLayer/DTOs/Category/CategoryDTO.cs
    }
}
