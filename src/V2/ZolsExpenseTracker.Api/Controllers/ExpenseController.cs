using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZolsExpenseTracker.Api.Models;

namespace ZolsExpenseTracker.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseController : ControllerBase
{
    private readonly ExpenseDbContext _context;

    public ExpenseController(ExpenseDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Expense>> AddExpense(Expense expense)
    {
        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAllExpenses), new { id = expense.Id}, expense);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExpenseDTO>>> GetAllExpenses(Guid id)
    {
        return await _context.Expenses
            .Select(x => ExpenseToDTO(x))
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExpenseDTO>> GetExpenseById(Guid id)
    {
        var expense = await _context.Expenses.FindAsync(id);

        if (expense == null)
        {
            return NotFound();
        }

        return ExpenseToDTO(expense);
    }

    private static ExpenseDTO ExpenseToDTO(Expense expense) => 
      new ExpenseDTO
    {
       Id = expense.Id,
       category = expense.Category,
       IsExpense = expense.IsExpense 
    };
}