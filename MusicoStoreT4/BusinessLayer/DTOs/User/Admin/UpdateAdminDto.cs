namespace BusinessLayer.DTOs.User
{
    public class UpdateAdminDto
    {
        public required int Id { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
    }
}
