using BusinessLayer.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Manufacturer
{
    public class ManufacturerDto
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public ICollection<ProductDto>? Products { get; set; }
    }
}
