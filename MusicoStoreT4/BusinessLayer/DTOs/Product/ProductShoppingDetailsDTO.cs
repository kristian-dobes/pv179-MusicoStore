using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Product
{
    public class ProductShoppingDetailsDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
