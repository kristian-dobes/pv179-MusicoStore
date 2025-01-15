namespace BusinessLayer.DTOs.User
{
    public class CustomerOrderDTO
    {
        public int CustomerId { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string PostalCode { get; set; }
    }
}
