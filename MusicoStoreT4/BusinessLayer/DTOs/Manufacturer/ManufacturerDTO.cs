using BusinessLayer.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Manufacturer
{
    public class ManufacturerDTO
    {
        public int ManufacturerId { get; set; }
<<<<<<<< HEAD:MusicoStoreT4/BusinessLayer/DTOs/Manufacturer/ManufacturerDto.cs
        public string Name { get; set; }
        public ICollection<ProductDto>? Products { get; set; }
        public DateTime DateCreated { get; set; }
========
        public required string Name { get; set; }
        public IEnumerable<ProductDto>? Products { get; set; }
>>>>>>>> feature/admin-endpoints:MusicoStoreT4/BusinessLayer/DTOs/Manufacturer/ManufacturerDTO.cs
    }
}
