namespace BusinessLayer.DTOs.User
{
    public class UserSummaryDTO
    {
        public int? UserId { get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }
        public int NumberOfOrders { get; set; }
    }
}
