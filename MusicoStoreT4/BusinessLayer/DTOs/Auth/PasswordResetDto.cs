namespace BusinessLayer.DTOs.Auth
{
    public class PasswordResetDto
    {
        public int UserId { get; init; }
        public int ChangedByUserId { get; init; }
        public required string NewPassword { get; init; }
    }
}
