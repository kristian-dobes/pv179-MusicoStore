using BusinessLayer.DTOs.Auth;
using static BusinessLayer.Facades.AuthFacade;

namespace BusinessLayer.Facades.Interfaces
{
    public interface IAuthFacade
    {
        Task<AuthenticationResult> ResetUserPassword(PasswordResetDto dto);
    }
}
