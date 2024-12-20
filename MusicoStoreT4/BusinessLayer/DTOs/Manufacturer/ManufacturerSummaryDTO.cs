using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Manufacturer
{
    public class ManufacturerSummaryDTO
    {
        public int ManufacturerId { get; set; }
        public required string Name { get; set; }
        public int NumberOfProducts { get; set; }
    }
}
