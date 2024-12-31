namespace WebMVC.Models.User
{
    public class UserSummaryViewModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public DateTime Created { get; set; }
    }
}
