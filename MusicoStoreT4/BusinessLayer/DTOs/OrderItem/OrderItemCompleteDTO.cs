namespace BusinessLayer.DTOs.OrderItem
{
    public class OrderItemCompleteDTO
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        //public ProductCompleteDTO Product { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string? ProductImageFilePath { get; set; }
        public int ProductQuantityInStock { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal TotalPricePerOrderItem { get; set; }
    }
}
