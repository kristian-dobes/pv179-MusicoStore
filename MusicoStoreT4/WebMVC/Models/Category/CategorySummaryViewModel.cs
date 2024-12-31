namespace WebMVC.Models.Category
{
    public class CategorySummaryViewModel
    {
        public required int CategoryId { get; set; }
        public required string Name { get; set; }
        public required int PrimaryProductCount { get; set; }
        public required int SecondaryProductCount { get; set; }
    }
}
