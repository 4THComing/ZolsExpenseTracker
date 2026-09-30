using Microsoft.EntityFrameworkCore;
using ZolsExpenseTracker.Core.Models;
using ZolsExpenseTracker.Core.Interfaces;
using ZolsExpenseTracker.Api.Infrastructure.Data;

namespace ZolsExpenseTracker.Api.Infrastructure.Repositories;

    public class ExpenseRepository : IExpenseRepository

    {
        private readonly ExpenseDbContext _context;

        public ExpenseRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        public async Task<List<Expense>> GetAllAsync() 
            => await _context.Expenses.ToListAsync();

        public async Task<Expense?> GetByIdAsync( Guid id)
            => await _context.Expenses.FindAsync(id);
        

        public async Task<Expense> AddAsync(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
            return expense;
        }

        public async Task<Expense> UpdateAsync(Expense expense)
        {
            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();
            return expense;  
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Expenses.FindAsync(id);
            if (entity != null)
            {
                _context.Expenses.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
   
