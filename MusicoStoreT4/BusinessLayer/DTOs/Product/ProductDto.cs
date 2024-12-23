namespace BusinessLayer.DTOs.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public string CategoryName { get; set; }
        public string ManufacturerName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
