using BusinessLayer.DTOs.User;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDBContext _context;

        public UserRepository(MyDBContext context)
        {
            _context = context;
        }

        public async Task<User?> AddAsync(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var addedEntity = (await _context.Users.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();
            return addedEntity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> UpdateAsync(User entity)
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

        public async Task<List<UserSummaryDto>> GetUserSummariesAsync()
        {
            var userSummaries = await _context.Users
                .Where(u => u.Role == Role.Customer)
                .Select(u => new UserSummaryDto
                {
                    UserId = u.Id,
                    Username = u.Username,
                    Role = u.Role,
                    TotalExpenditure = u.Orders
                        .SelectMany(o => o.OrderItems)
                        .Sum(oi => oi.Price * oi.Quantity)
                })
                .ToListAsync();

            return userSummaries;
        }

        public async Task<IEnumerable<User>> WhereAsync(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users.Where(predicate).ToListAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users.AnyAsync(predicate);
        }
    }
}
