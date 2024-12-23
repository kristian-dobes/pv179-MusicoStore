namespace WebMVC.Models.Product
{
    public class ProductSummaryViewModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required int CategoryId { get; set; }
        public required int ManufacturerId { get; set; }
    }
}
