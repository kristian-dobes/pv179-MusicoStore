namespace BusinessLayer.DTOs.User.Customer
{
    public class CustomerSegmentStatsDto
    {
        public CustomerDto CustomerDTO { get; set; }
        public decimal TotalExpenditure { get; set; }
        public bool IsInfrequent { get; set; }
    }
}
