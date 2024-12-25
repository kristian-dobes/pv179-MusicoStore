namespace WebMVC.Models.Product
{
    public class ProductHomeViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageFilePath { get; set; }
    }
}
