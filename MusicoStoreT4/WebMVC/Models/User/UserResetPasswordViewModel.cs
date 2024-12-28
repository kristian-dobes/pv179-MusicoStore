using BusinessLayer.DTOs.User;

namespace WebMVC.Models.User
{
    public class UserResetPasswordViewModel
    {
        public UserSummaryDTO? UserToReset { get; set; }
        public string NewPassword { get; set; } = "";
        public string ConfirmPassword { get; set; } = "";
    }
}
