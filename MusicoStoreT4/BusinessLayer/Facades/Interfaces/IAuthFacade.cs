using BusinessLayer.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLayer.Facades.AuthFacade;

namespace BusinessLayer.Facades.Interfaces
{
    public interface IAuthFacade
    {
        Task<AuthenticationResult> ResetUserPassword(PasswordResetDto dto);
    }
}
