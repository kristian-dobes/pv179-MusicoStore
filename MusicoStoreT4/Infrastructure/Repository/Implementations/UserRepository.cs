using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDBContext _context;

        public UserRepository(MyDBContext context)
        {
            _context = context;
        }

        public async Task<User?> Add(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var addedEntity = (await _context.Users.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();
            return addedEntity;
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> Update(User entity)
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
    }
}
