﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Product
{
    public class TopSellingProductDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<ProductSalesDto> Products { get; set; } = new List<ProductSalesDto>();
    }
}
