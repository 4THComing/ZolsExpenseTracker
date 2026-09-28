using Microsoft.EntityFrameworkCore;
using ZolsExpenseTracker.Api.Models;
using ZolsExpenseTracker.Api.Infrastructure.Data;

namespace ZolsExpenseTracker.Api.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository

    {
        private readonly ExpenseDbContext _context;

        public UserRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task UpdateUser(User user)
        {
           _context.Update(user);
        }

        public async Task DeleteUser(User user)
        {
            _context.Remove(user);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}        