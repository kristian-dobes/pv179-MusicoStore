using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class CategorySummaryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int ProductCount { get; set; }
    }
}
