namespace BusinessLayer.DTOs.Product
{
    public class ProductSalesDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int TotalUnitsSold { get; set; }
        public decimal Revenue { get; set; }
    }
}
