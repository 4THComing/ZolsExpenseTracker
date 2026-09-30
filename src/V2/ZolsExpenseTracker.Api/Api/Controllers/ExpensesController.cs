using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZolsExpenseTracker.Api.DTOs.Expenses;
using ZolsExpenseTracker.Core.Models;
using ZolsExpenseTracker.Core.Interfaces;
using ZolsExpenseTracker.Api.Infrastructure.Data;

namespace ZolsExpenseTracker.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseController : ControllerBase
{
    private readonly ExpenseDbContext _context;
    private readonly IExpenseRepository _expenseRepository;

    public ExpenseController(ExpenseDbContext context, IExpenseRepository expenseRepository)
    {
        _context = context;
        _expenseRepository = expenseRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<ExpenseDTO>>> GetAllAsync()
    {
        var expenses = await _expenseRepository.GetAllAsync();
        var dtos = expenses.Select(e => new ExpenseDTO
        {
            Id = e.Id,
            Description = e.Description,
            Amount = e.Amount,
            Category = e.Category
        }).ToList();
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExpenseDTO>> GetByIdAsync(Guid id)
    {
        var expense = await _expenseRepository.GetByIdAsync(id);

        if (expense == null)
        {
            return NotFound();
        }

        return ExpenseToDTO(expense);
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> UpdateAsync(Guid id, UpdateExpenseDTO updateExpenseDTO)
    {
        if (id != updateExpenseDTO.Id)
        {
            return BadRequest();
        }

        var expense = await _context.Expenses.FindAsync(id);
        if (expense == null)
        {
            return NotFound();
        }

        expense.Category = updateExpenseDTO.Category;
        expense.Description = updateExpenseDTO.Description;
        expense.Amount = updateExpenseDTO.Amount;
        expense.Date = updateExpenseDTO.Date;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!ExpenseExists(id))
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<ExpenseDTO>> AddAsync(CreateExpenseDTO createExpenseDTO)
    {
        var expense = new Expense
        {
            Category = createExpenseDTO.Category,
            Description = createExpenseDTO.Description,
            Amount = createExpenseDTO.Amount,
            Date = createExpenseDTO.Date
        };

        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetByIdAsync),
            new { id = expense.Id },
            ExpenseToDTO(expense));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var expense = await _context.Expenses.FindAsync(id);
        if (expense == null)
        {
            return NotFound();
        }

        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ExpenseExists(Guid id)
    {
        return _context.Expenses.Any(e => e.Id == id);
    }

    private static ExpenseDTO ExpenseToDTO(Expense expense) =>
      new ExpenseDTO
      {
          Id = expense.Id,
          Category = expense.Category,
          Description = expense.Description,
          Amount = expense.Amount,
          Date = expense.Date
      };
}