namespace ZolsExpenseTracker.Api.Models;

public class ExpenseDTO
{
    public Guid Id { get; set; }

    public CategorySelection category { get; set; }

    public bool IsExpense { get; set; }

}   
