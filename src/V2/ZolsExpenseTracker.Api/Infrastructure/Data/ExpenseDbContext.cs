using Microsoft.EntityFrameworkCore;
using ZolsExpenseTracker.Api.Models;

namespace ZolsExpenseTracker.Api.Infrastructure.Data;

    public class ExpenseDbContext : DbContext
    {
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options)
            : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; } = null!;
        public DbSet<Vendor> Vendors { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!; 
        
    }

