using Microsoft.EntityFrameworkCore;
using ZolsExpenseTracker.Api.Core.Interface;
using ZolsExpenseTracker.Api.DTOs.Expenses;
using ZolsExpenseTracker.Infrastructure.Data;
using ZolsExpenseTracker.Api.Models;

namespace ZolsExpenseTracker.Api.Core.Services;

public class ExpenseService(ExpenseDbContext context) : IExpenseService
{
    public async Task<IEnumerable<ExpenseDTO>> GetAllAsync()
    => await context.Expenses
    .Select(e => new ExpenseDTO(e.Id, e.Description, e.Amount, e.Date))
    .ToListAsync();

    public async Task<ExpenseDTO> GetByIdAsync(Guid Id)
    => await context.Expenses.Where(x => x.Id == id)
    .Select(e => new ExpenseDTO(e.Id, e.Description, e.Amount, e.Date))
    .FirstOrDefaultAsync();

    public async Task<ExpenseDTO> CreateAsync(CreateExpenseDTO dto)
    {
        var expense = new ExpenseService
        {
            Id = Guid.NewGuid(),
            Description = dto.Description,
            Amount = dto.Amount,
            Category = dto.Category,
            Date = DateTime.UtcNow
        };
        context.Expenses.Add(expense);
        await context.SaveChangesAsync();
        return new ExpenseDTO(expense.Id, expense.Description, expense.Amount, expense.Category, expense.Date);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var e = await context.Expenses.FindAsync(id);
        if (e == null) return false;
        context.Expenses.Remove(e);
        await context.SaveChangesAsync();
        return true;
    }
}