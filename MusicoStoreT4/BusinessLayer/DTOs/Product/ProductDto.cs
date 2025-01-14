namespace BusinessLayer.DTOs.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public string PrimaryCategoryName { get; set; }
        public IEnumerable<string> SecondaryCategories { get; set; } = [];
        public string ManufacturerName { get; set; }
        public DateTime DateCreated { get; set; }
        public string ImageFilePath { get; set; }
    }
}
