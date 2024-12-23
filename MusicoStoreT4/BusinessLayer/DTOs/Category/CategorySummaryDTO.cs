﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Category
{
    public class CategorySummaryDTO
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public required int ProductCount { get; set; }
    }
}
