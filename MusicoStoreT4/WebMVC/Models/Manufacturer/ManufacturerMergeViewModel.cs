using BusinessLayer.DTOs.Manufacturer;
using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models.Manufacturer
{
    public class ManufacturerMergeViewModel
    {
        [Required]
        [Display(Name = "Source Manufacturer")]
        public int SourceManufacturerId { get; set; }
        [Required]
        [Display(Name = "Destination Manufacturer")]
        public int DestinationManufacturerId { get; set; }

        public IEnumerable<ManufacturerSummaryDTO> Manufacturers { get; set; } = [];
    }
}
