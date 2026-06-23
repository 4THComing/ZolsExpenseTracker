using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZolsExpenseTracker.Api.Models;

namespace ZolsExpenseTracker.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseController : ControllerBase
{
    private readonly ExpenseContext _context;

    public ExpenseController(ExpenseContext context)
    {
        _context = context;
    }

}