using BusinessLayer.DTOs.User.Admin;

namespace BusinessLayer.DTOs.User.Customer
{
    public class CreateCustomerDto : CreateAdminDto
    {
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string PostalCode { get; set; }
    }
}
