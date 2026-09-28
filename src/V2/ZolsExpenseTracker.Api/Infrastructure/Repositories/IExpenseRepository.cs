using ZolsExpenseTracker.Api.Models;

namespace ZolsExpenseTracker.Api.Infrastructure.Repositories
{
    public interface IExpenseRepository 
    {
        Task<IEnumerable<Expense>> GetAllExpensesAsync();
        Task<Expense?> GetExpenseByIdAsync(Guid id);
        Task AddExpenseAsync(Expense expense);
        Task UpdateExpense(Expense expense);
        Task DeleteExpense(Expense expense);
        Task SaveChangesAsync();
    }
}    