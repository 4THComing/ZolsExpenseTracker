using ZolsExpenseTracker.Core.Interfaces;
using ZolsExpenseTracker.Core.Models;
using ZolsExpenseTracker.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ZolsExpenseTracker.Api.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ExpenseDbContext _context;
        public UserRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        => await _context.Users.ToListAsync();

        public async Task<User?> GetByIdAsync(Guid id)
        => await _context.Users.FindAsync(id);

        public async Task<User?> GetByEmailAsync(string email)
        => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<User> AddAsync(User user)
        {
            var u = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return u.Entity;
        }

        public async Task<User> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Users.FindAsync(id);            
            if (entity != null)
            {
                _context.Users.Remove(entity);
                await _context.SaveChangesAsync();
            } 
        }
    }
}