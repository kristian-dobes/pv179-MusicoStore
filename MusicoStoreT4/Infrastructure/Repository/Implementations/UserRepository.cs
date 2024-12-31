using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        public IQueryable<OrderItem> GetUserOrderItemsQuery(int userId)
        {
            return _context.OrderItems
                .Where(oi => oi.Order.UserId == userId)
                .Include(oi => oi.Product);
        }

        public async Task<string?> GetIdentityUserIdByUserIdAsync(int userId)
        {
            return await _userManager.Users
                .Where(u => u.UserId == userId)
                .Select(u => u.Id)
                .FirstOrDefaultAsync();
        }
    }
}
