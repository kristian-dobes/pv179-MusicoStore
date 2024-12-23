using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Manufacturer
{
    public class ManufacturerUpdateDTO
    {
        [MinLength(1)]
        [MaxLength(100)]
        public required string Name { get; set; }
    }
}
