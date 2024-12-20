namespace WebMVC.Models.Manufacturer
{
    public class ManufacturerSummaryViewModel
    {
        public required int ManufacturerId { get; set; }
        public required string Name { get; set; }
        public required int NumberOfProducts { get; set; }
    }
}
