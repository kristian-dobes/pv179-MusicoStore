using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Category
{
    public class CategoryBasicDto
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
    }
}
