namespace BusinessLayer.DTOs.Product
{
    public class FilterProductDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? CategoryId { get; set; }
        public int? ManufacturerId { get; set; }
    }
}
