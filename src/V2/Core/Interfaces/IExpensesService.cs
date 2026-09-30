using ZolsExpenseTracker.Core.Models;

namespace ZolsExpenseTracker.Core.Interfaces;

public interface IExpenseService
{
    Task<List<Expense>> GetAllAsync();
    Task<Expense?> GetByIdAsync(Guid id);
    Task<Expense> CreateAsync(Expense expense);
    Task<bool> DeleteAsync(Guid id);
}