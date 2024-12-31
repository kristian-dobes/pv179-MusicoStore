using BusinessLayer.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Category
{
    public class CategoryProductsDTO
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public IEnumerable<ProductSummaryDTO>? PrimaryProducts { get; set; } = [];
        public int PrimaryProductCount { get; set; }
        public IEnumerable<ProductSummaryDTO>? SecondaryProducts { get; set; } = [];
        public int SecondaryProductCount { get; set; }
    }
}
