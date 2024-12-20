namespace BusinessLayer.DTOs.Product
{
    public class CreateProductDTO
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required int CategoryId { get; set; }
        public required int ManufacturerId { get; set; }
    }
}
