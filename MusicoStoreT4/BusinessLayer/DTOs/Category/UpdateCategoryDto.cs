﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Category
{
    public class UpdateCategoryDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }
}
