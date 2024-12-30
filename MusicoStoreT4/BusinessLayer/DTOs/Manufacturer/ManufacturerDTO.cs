﻿using BusinessLayer.DTOs.Product;
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
        public required string Name { get; set; }
        public IEnumerable<ProductDto>? Products { get; set; }
        public int ProductCount { get; set; }
    }
}
