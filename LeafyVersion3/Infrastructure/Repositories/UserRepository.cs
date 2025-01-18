using LeafyAPI.Infrastructure.Models;
using LeafyVersion3.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace LeafyVersion3.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly AppDbContext? _context;

        public UserRepository(AppDbContext? context) { 
            _context = context; 
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context!.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task CreateUserAsync(User user)
        {
            _context!.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task UpdateUserAsync(User entity)
        {
            var existingUser = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == entity.Id);

            if (existingUser == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            if (entity.Username != existingUser.Username)
            {
                _context.Entry(entity).Property(e => e.Username).IsModified = true;
            }

            if (!string.IsNullOrWhiteSpace(entity.PasswordHash) && entity.PasswordHash != existingUser.PasswordHash)
            {
                _context.Entry(entity).Property(e => e.PasswordHash).IsModified = true;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> UsernameExistsAsync(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username); // Adjust to your model
        }
    }
}
