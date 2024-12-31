using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;
using Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly MyDBContext _context;
        private readonly UserManager<LocalIdentityUser> _userManager;

        public UserRepository(MyDBContext context, UserManager<LocalIdentityUser> userManager) : base(context)
        {
            _context = context;
            _userManager = userManager;
        }

        public override async Task<bool> UpdateAsync(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var existingUser = await _context.Users.FindAsync(entity.Id);

            if (existingUser == null)
                return false;

            existingUser.Username = entity.Username;
            existingUser.Email = entity.Email;
            existingUser.Role = entity.Role;

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User?> GetUserWithOrdersAsync(int userId)
        {
            return await _context.Users
                .Include(u => u.Orders)
                .ThenInclude(o => o.OrderItems)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<string?> GetIdentityUserIdByUserIdAsync(int userId)
        {
            return await _userManager.Users
                .Where(u => u.UserId == userId)
                .Select(u => u.Id)
                .FirstOrDefaultAsync();
        }

        //public async Task<List<UserSummaryDto>> GetUserSummariesAsync()
        //{
        //    var userSummaries = await _context.Users
        //        .Where(u => u.Role == Role.Customer)
        //        .Select(u => new UserSummaryDto
        //        {
        //            UserId = u.Id,
        //            Username = u.Username,
        //            Role = u.Role,
        //            TotalExpenditure = (decimal)u.Orders
        //                .SelectMany(o => o.OrderItems)
        //                .Sum(oi => (double)(oi.Price * oi.Quantity))
        //        })
        //        .ToListAsync();

        //    return userSummaries;
        //}
    }
}
