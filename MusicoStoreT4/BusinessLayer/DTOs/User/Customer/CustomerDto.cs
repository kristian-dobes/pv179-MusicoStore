using BusinessLayer.DTOs.User.Admin;

namespace BusinessLayer.DTOs.User.Customer
{
    public class CustomerDto : AdminDto
    {
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string PostalCode { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not CustomerDto other)
                return false;

            return PhoneNumber == other.PhoneNumber &&
                   Address == other.Address &&
                   City == other.City &&
                   State == other.State &&
                   PostalCode == other.PostalCode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PhoneNumber, Address, City, State, PostalCode, base.GetHashCode());
        }
    }
}
