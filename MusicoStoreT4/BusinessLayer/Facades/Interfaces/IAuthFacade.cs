using BusinessLayer.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Facades.Interfaces
{
    public interface IAuthFacade
    {
        Task ResetUserPassword(PasswordResetDto dto);
    }
}
