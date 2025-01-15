using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOs.Manufacturer
{
    public class ManufacturerUpdateDTO
    {
        [MinLength(1)]
        [MaxLength(100)]
        public required string Name { get; set; }
    }
}
