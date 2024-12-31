namespace BusinessLayer.DTOs.Product
{
    public class ProductMostBoughtDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfBuys { get; set; }
    }
}
