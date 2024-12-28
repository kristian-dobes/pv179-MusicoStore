using BusinessLayer.DTOs.Auth;
using BusinessLayer.Facades.Interfaces;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLayer.Facades
{
    public class AuthFacade : IAuthFacade
    {
        private readonly UserManager<LocalIdentityUser> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AuthFacade(
            UserManager<LocalIdentityUser> userManager,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork
            )
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public class AuthenticationResult
        {
            public bool Succeeded { get; set; }
            public List<string> Errors { get; set; } = new List<string>();
        }

        public async Task<AuthenticationResult> ResetUserPassword(PasswordResetDto dto)
        {
            var result = new AuthenticationResult();

            var changingUser = await _unitOfWork.UsersRep.GetByIdAsync(dto.ChangedByUserId);
            if ( changingUser == null )
            {
                result.Errors.Add("Changing user not found");
                return result;
            }

            // Get users GUID
            var identityUserId = await _userRepository.GetIdentityUserIdByUserIdAsync(dto.UserId);
            if (identityUserId == null)
            {
                result.Errors.Add("User to change password to not found.");
                return result;
            }

            // Find by GUID
            var userToChangePasswordTo = await _userManager.FindByIdAsync(identityUserId);
            if (userToChangePasswordTo == null)
            {
                result.Errors.Add("User to change password to not found.");
                return result;
            }

            // should admin be able to change password to another admin? ... yes

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(userToChangePasswordTo);

            // Reset password
            var resetResult = await _userManager.ResetPasswordAsync(userToChangePasswordTo, resetToken, dto.NewPassword);

            if (!resetResult.Succeeded)
            {
                result.Errors.AddRange(resetResult.Errors.Select(e => e.Description));
                return result;
            }

            result.Succeeded = true;
            return result;
        }
    }
}
