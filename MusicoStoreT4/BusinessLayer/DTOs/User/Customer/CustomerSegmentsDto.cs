namespace BusinessLayer.DTOs.User.Customer
{
    public class CustomerSegmentsDto
    {
        public required List<CustomerDto> HighValueCustomers { get; set; }
        public required List<CustomerDto> InfrequentCustomers { get; set; }
    }
}
