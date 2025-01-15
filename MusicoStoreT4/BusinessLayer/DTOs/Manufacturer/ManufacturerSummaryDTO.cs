namespace BusinessLayer.DTOs.Manufacturer
{
    public class ManufacturerSummaryDTO
    {
        public int ManufacturerId { get; set; }
        public required string Name { get; set; }
        public int ProductCount { get; set; }
    }
}
