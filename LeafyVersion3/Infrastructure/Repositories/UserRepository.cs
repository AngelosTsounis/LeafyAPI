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
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context!.Users.FirstOrDefaultAsync(u => u.Email == email);
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
            _context!.Users.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
