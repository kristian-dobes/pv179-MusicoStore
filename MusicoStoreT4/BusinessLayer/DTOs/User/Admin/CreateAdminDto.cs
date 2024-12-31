namespace BusinessLayer.DTOs.User.Admin
{
    public class CreateAdminDto
    {
        public required string Email { get; set; }
        public required string Username { get; set; }
    }
}
