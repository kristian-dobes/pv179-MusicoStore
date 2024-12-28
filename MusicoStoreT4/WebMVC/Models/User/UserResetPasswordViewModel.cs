using BusinessLayer.DTOs.User;
using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models.User
{
    public class UserResetPasswordViewModel
    {
        public UserSummaryDTO? UserToReset { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; } = "";
        
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = "";
    }
}
