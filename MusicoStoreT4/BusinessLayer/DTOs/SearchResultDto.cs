using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Category;
using BusinessLayer.DTOs.Manufacturer;
using BusinessLayer.DTOs.Product;

namespace BusinessLayer.DTOs
{
    public class SearchResultDto
    {
        public IEnumerable<ProductDto> Products { get; set; }
        public int TotalProductCount { get; set; }
        public IEnumerable<ManufacturerDTO> Manufacturers { get; set; }
        public IEnumerable<CategoryDTO> Categories { get; set; }
    }
}
