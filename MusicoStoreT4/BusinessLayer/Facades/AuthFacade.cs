using BusinessLayer.DTOs.Auth;
using BusinessLayer.Facades.Interfaces;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Identity;

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

        public async Task ResetUserPassword(PasswordResetDto dto)
        {
            var changingUser = await _unitOfWork.UsersRep.GetByIdAsync(dto.ChangedByUserId) ?? throw new Exception("Changing user not found");

            // Get users GUID
            var identityUserId = await _userRepository.GetIdentityUserIdByUserIdAsync(dto.UserId) ?? throw new Exception("User to change password to not found");
            // Find by GUID
            var userToChangePasswordTo = await _userManager.FindByIdAsync(identityUserId) ?? throw new Exception("User to change password to not found");

            // should admin be able to change password to another admin? ... yes

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(userToChangePasswordTo);

            // Reset password
            var resetResult = await _userManager.ResetPasswordAsync(userToChangePasswordTo, resetToken, dto.NewPassword);

            if (!resetResult.Succeeded)
            {
                throw new Exception("Password reset failed");
            }
        }
    }
}
