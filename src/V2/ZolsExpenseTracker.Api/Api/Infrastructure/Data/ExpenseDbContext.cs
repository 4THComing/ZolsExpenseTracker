using Microsoft.EntityFrameworkCore;
using ZolsExpenseTracker.Core.Models;

namespace ZolsExpenseTracker.Api.Infrastructure.Data;

    public class ExpenseDbContext : DbContext
    {
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options)
            : base(options)
        {
        }

        public DbSet<Expense> Expenses => Set<Expense>();
    }

