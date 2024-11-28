using LeafyVersion3.Contracts.Requests;
using LeafyVersion3.Infrastructure.Model;

namespace LeafyVersion3.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User?> GetUserByIdAsync(Guid userId);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task UpdateUserAsync(User entity);
        Task CreateUserAsync(User user);
    }
}
