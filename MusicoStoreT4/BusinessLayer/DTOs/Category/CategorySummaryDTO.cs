namespace BusinessLayer.DTOs.Category
{
    public class CategorySummaryDTO
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public required int PrimaryProductCount { get; set; }
        public required int SecondaryProductCount { get; set; }
    }
}
