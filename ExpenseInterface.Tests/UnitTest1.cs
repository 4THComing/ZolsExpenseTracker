using ExpenseInterface.Services;
using ExpenseInterface.Models;

namespace ExpenseInterface.Tests;

public class UnitTest1
{
    [Fact]
    public void GetTotalExpenses_ReturnsCorrectTotal()
    {
       // Arrange 
       var manager = new ExpenseManager();

       var expenses = new List<Expense>
       {
          new Expense(CategorySelection.Food, "Tacos", 100, DateTime.Now),
          new Expense(CategorySelection.Transportation, "Bus Pass", 50, DateTime.Now),
          new Expense(CategorySelection.Entertainment, "Movie Tickets", 75, DateTime.Now),
          new Expense(CategorySelection.Utilities, "Electricity Bill", 200, DateTime.Now),
          new Expense(CategorySelection.Other, "Office Supplies", 25, DateTime.Now)
       };

       // Act
       var result = manager.GetTotalExpenses(expenses);

       // Assert
         Assert.Equal(450, result);
    }
    
    [Fact]
    public void GetTotalExpenses_ReturnsZeroForEmptyList()
    {
        // Arrange
        var manager = new ExpenseManager();

        var expenses = new List<Expense>();

        // Act
        var result = manager.GetTotalExpenses(expenses);   

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetHighestExpense_ReturnsHighestExpense()
    {
        // Arrange
        var manager = new ExpenseManager();

        var expenses = new List<Expense>
        {
            new Expense(CategorySelection.Food, "Tacos", 100, DateTime.Now),
            new Expense(CategorySelection.Transportation, "Bus Pass", 50, DateTime.Now),
            new Expense(CategorySelection.Entertainment, "Movie Tickets", 75, DateTime.Now),
            new Expense(CategorySelection.Utilities, "Electricity Bill", 200, DateTime.Now),
            new Expense(CategorySelection.Other, "Office Supplies", 25, DateTime.Now)
        };  

        // Act
        var result = manager.GetHighestExpense(expenses);

        // Assert
        Assert.Equal(200, result);
    }

    [Fact]
    public void GetLowestExpense_ReturnsLowestExpense()
    {
        // Arrange
        var manager = new ExpenseManager();

        var expenses = new List<Expense>
        {
            new Expense(CategorySelection.Food, "Tacos", 100, DateTime.Now),
            new Expense(CategorySelection.Transportation, "Bus Pass", 50, DateTime.Now),
            new Expense(CategorySelection.Entertainment, "Movie Tickets", 75, DateTime.Now),
            new Expense(CategorySelection.Utilities, "Electricity Bill", 200, DateTime.Now),
            new Expense(CategorySelection.Other, "Office Supplies", 25, DateTime.Now)
        };  

        // Act
        var result = manager.GetLowestExpense(expenses);

        // Assert
        Assert.Equal(25, result);
    }

    [Fact]
    public void GetAverageExpense_ReturnsAverageExpense()
    {
        // Arrange
        var manager = new ExpenseManager();

        var expenses = new List<Expense>
        {
            new Expense(CategorySelection.Food, "Tacos", 100, DateTime.Now),
            new Expense(CategorySelection.Transportation, "Bus Pass", 50, DateTime.Now),
            new Expense(CategorySelection.Entertainment, "Movie Tickets", 75, DateTime.Now),
            new Expense(CategorySelection.Utilities, "Electricity Bill", 200, DateTime.Now),
            new Expense(CategorySelection.Other, "Office Supplies", 25, DateTime.Now)
        };  

        // Act
        var result = manager.GetAverageExpense(expenses);

        // Assert
        Assert.Equal(90, result);
    }
}
