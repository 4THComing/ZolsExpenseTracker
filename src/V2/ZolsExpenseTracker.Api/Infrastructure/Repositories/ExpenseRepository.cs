using Microsoft.EntityFrameworkCore;
using ZolsExpenseTracker.Api.Models;
using ZolsExpenseTracker.Api.Infrastructure.Data;

namespace ZolsExpenseTracker.Api.Infrastructure.Repositories
{
    public class ExpenseRepository : IExpenseRepository

    {
        private readonly ExpenseDbContext _context;

        public ExpenseRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync() 
        {
            return await _context.Expenses.ToListAsync();
        }

        public async Task<Expense?> GetExpenseByIdAsync( Guid id)
        {
            return await _context.Expenses.FindAsync(id);
        }

        public async Task AddExpenseAsync(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
        }

        public async Task UpdateExpense(Expense expense)
        {
            _context.Expenses.Update(expense);
        }

        public async Task DeleteExpense(Expense expense)
        {
            _context.Expenses.Remove(expense);
        }
        
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
   
}
