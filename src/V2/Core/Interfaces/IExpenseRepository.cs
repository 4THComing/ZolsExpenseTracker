using ZolsExpenseTracker.Core.Models;

namespace ZolsExpenseTracker.Core.Interfaces;

public interface IExpenseRepository 
 {
    Task<List<Expense>> GetAllAsync();
    Task<Expense?> GetByIdAsync(Guid id);
    Task<Expense> AddAsync(Expense expense);
    Task<Expense> UpdateAsync(Expense expense);
    Task DeleteAsync(Guid id);
 }
    