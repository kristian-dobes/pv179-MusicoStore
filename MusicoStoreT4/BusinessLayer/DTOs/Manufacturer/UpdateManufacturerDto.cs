using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Manufacturer
{
    public class UpdateManufacturerDto
    {
        public required int ManufacturerId { get; set; }
        public string? Name { get; set; }
    }
}
