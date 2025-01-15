namespace BusinessLayer.DTOs.User.Customer
{
    public class CustomerDetailsDto
    {
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string PostalCode { get; set; }
    }
}
