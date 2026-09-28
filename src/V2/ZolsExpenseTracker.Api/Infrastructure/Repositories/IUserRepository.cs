using ZolsExpenseTracker.Api.Models;

namespace ZolsExpenseTracker.Api.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User?> GetUserByIdAsync( Guid id);
        Task AddUserAsync(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
        Task SaveChangesAsync();
    }
}