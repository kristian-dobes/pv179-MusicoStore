namespace BusinessLayer.DTOs.Product
{
    public class UpdateProductDto
    {
        public required int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? CategoryId { get; set; }
        public int? ManufacturerId { get; set; }
    }
}
