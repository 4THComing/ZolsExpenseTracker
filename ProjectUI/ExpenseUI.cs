using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseInterface.Services;
using ExpenseInterface.Storage;
using ExpenseInterface.Models;

namespace ExpenseInterface.ProjectUI
{
    public class ExpenseUI
    {
        public static void AddExpenseFlow(ExpenseStore expenseStore)
        { 
            CategorySelection category = default(CategorySelection);
            string? description = string.Empty;
            double amount = 0.00;
            DateTime date = DateTime.Now;
                
            Console.WriteLine("Enter Valid Category from the following: \n1. Food \n2. Transportation \n3. Utilities \n4. Entertainment \n5. Healthcare \n6. Education \n7. Other");
            Console.Write("1. Enter Expense Category: ");
            var choice = Console.ReadLine();

            while (true)
            {
            switch (choice)
            {
                case "1":
                    category = CategorySelection.Food;
                    break;
                case "2":
                    category = CategorySelection.Transportation;
                    break;
                case "3":
                    category = CategorySelection.Utilities;
                    break;
                case "4":
                    category = CategorySelection.Entertainment;
                    break;
                case "5":
                    category = CategorySelection.Healthcare;
                    break;
                case "6":
                    category = CategorySelection.Education;
                    break;
                case "7":
                    category = CategorySelection.Other;
                    break;    
                default:
                        category = CategorySelection.None;
                        Console.WriteLine("Invalid choice, Please select a valid category from the list.");
                        Console.Write("1. Enter Expense Category: ");
                        choice = Console.ReadLine();
                        continue;
            }
            break;
            }

            Console.Write("2. Enter Expense Description: ");
            description = Console.ReadLine();
            while (true)
            {
                bool InvalidDescription = string.IsNullOrWhiteSpace(description) || description.Any(char.IsDigit);
                if (InvalidDescription)
                {
                    Console.WriteLine("Description is required. Please enter a valid description.");
                    Console.Write("2. Enter Expense Description: ");
                    description = Console.ReadLine();
                } 
                else
                {
                    break;
                }
            } 

            Console.Write("3. Enter Expense Amount: ");
            amount = double.TryParse(Console.ReadLine(), out amount) ? amount : 0.00;
            while (true)
            {
                bool InvalidAmount = amount <= 0 || amount.ToString().Any(char.IsLetter);
                if (InvalidAmount)
                {
                    Console.WriteLine("Invalid amount, Please enter a figure greater than 0.00");
                    Console.Write("3. Enter Expense Amount: ");
                    amount = double.TryParse(Console.ReadLine(), out amount) ? amount : 0.00;
                }
                else
                {
                    break;
                }
            } 

            Console.Write("5. Enter Expense Date: ");
            DateTime parsedDate;
            bool isValidDate = DateTime.TryParse(Console.ReadLine(), out parsedDate);

            while (!isValidDate)
            {
                Console.WriteLine("Invalid date format. Please enter a valid date (e.g., 2024-12-31).");
                Console.Write("5. Enter Expense Date: ");
                isValidDate = DateTime.TryParse(Console.ReadLine(), out parsedDate);   
            }

            date = parsedDate;

        try
        {
            var expense = new Expense(category, description, amount, date);
            expenseStore.AddExpense(expense);
        } 
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error adding expense: {ex.Message}");


        }    
        }

     public static void UpdateExpenseFlow(ExpenseStore expenseStore)
{
    List<Expense> expenses = expenseStore.GetExpenses().ToList();

    if (!expenses.Any())
    {
        Console.WriteLine("No expenses found to update.");
        return;
    }

    Console.WriteLine("Expenses:");

    for (int i = 0; i < expenses.Count; i++)
    {
        var expense = expenses[i];

        Console.WriteLine($"{i + 1}. Category: {expense.Category}, Description: {expense.Description}, Amount: {expense.Amount:C}, Date: {expense.Date:yyyy-MM-dd}");
    }

    Console.WriteLine("Enter the number of the expense you want to update: ");

    var selectedExpense = Console.ReadLine();

    if (selectedExpense == null || !int.TryParse(selectedExpense, out int expenseIndex))
        throw new ArgumentException("Invalid expense number.");

    if (expenseIndex < 1 || expenseIndex > expenses.Count)
        throw new ArgumentException("Expense number out of bounds.");

    var expenseToUpdate = expenses[expenseIndex - 1];

    Console.WriteLine($"Current Expense: Category: {expenseToUpdate.Category}, Description: {expenseToUpdate.Description}, Amount: {expenseToUpdate.Amount:C}, Date: {expenseToUpdate.Date:yyyy-MM-dd}");

    bool validCategory = false;

    while (!validCategory)
    {
        Console.WriteLine("Enter new expense category from the following:");
        Console.WriteLine("1. Food");
        Console.WriteLine("2. Transportation");
        Console.WriteLine("3. Utilities");
        Console.WriteLine("4. Entertainment");
        Console.WriteLine("5. Healthcare");
        Console.WriteLine("6. Education");
        Console.WriteLine("7. Other");

        Console.Write("1. Enter new expense category: ");

        var newCategoryInput = Console.ReadLine();

        switch (newCategoryInput)
        {
            case "1":
                expenseToUpdate.Category = CategorySelection.Food;
                validCategory = true;
                break;

            case "2":
                expenseToUpdate.Category = CategorySelection.Transportation;
                validCategory = true;
                break;

            case "3":
                expenseToUpdate.Category = CategorySelection.Utilities;
                validCategory = true;
                break;

            case "4":
                expenseToUpdate.Category = CategorySelection.Entertainment;
                validCategory = true;
                break;

            case "5":
                expenseToUpdate.Category = CategorySelection.Healthcare;
                validCategory = true;
                break;

            case "6":
                expenseToUpdate.Category = CategorySelection.Education;
                validCategory = true;
                break;

            case "7":
                expenseToUpdate.Category = CategorySelection.Other;
                validCategory = true;
                break;

            default:
                Console.WriteLine("Invalid category input. Please try again.");
                break;
        }
    }

    Console.WriteLine("Enter new expense description: ");
    var newDescriptionInput = Console.ReadLine();

    while (true)
    {
        bool invalidDescription = string.IsNullOrWhiteSpace(newDescriptionInput) || newDescriptionInput.Any(char.IsDigit);

        if (invalidDescription)
        {
            Console.WriteLine("Description is required. Please enter a valid description.");
            Console.Write("2. Enter new expense description: ");
            newDescriptionInput = Console.ReadLine();
        }
        else
        {
            expenseToUpdate.Description = newDescriptionInput;
            break;
        }
    }

    Console.WriteLine("Enter new expense amount: ");
    double newAmountInput = double.TryParse(Console.ReadLine(), out double parsedAmount) ? parsedAmount : 0.00;

    while (true)
    {
        bool invalidAmount = newAmountInput <= 0;

        if (invalidAmount)
        {
            Console.WriteLine("Invalid amount. Please enter a figure greater than 0.00");
            Console.Write("3. Enter new expense amount: ");
            newAmountInput = double.TryParse(Console.ReadLine(), out parsedAmount) ? parsedAmount : 0.00;
        }
        else
        {
            expenseToUpdate.Amount = newAmountInput;
            break;
        }
    }

    Console.WriteLine("Enter new expense date: ");
    DateTime parsedDate;
    bool isValidDate = DateTime.TryParse(Console.ReadLine(), out parsedDate);

    while (!isValidDate)
    {
        Console.WriteLine("Invalid date format. Please enter a valid date (e.g., 2024-12-31).");
        Console.Write("5. Enter new expense date: ");
        isValidDate = DateTime.TryParse(Console.ReadLine(), out parsedDate);
    }

    expenseToUpdate.Date = parsedDate;
    Console.WriteLine("Expense updated successfully.");
}

        public static void ViewExpenseFlow(ExpenseStore expenseStore)
        {
            var expenses = expenseStore.GetExpenses();

            if (expenses.Any()) 
            {
                Console.WriteLine("Expenses found:");
            }
            else
            {
                Console.WriteLine("No expenses found.");
            }

            foreach (var expense in expenses)
            {
                Console.WriteLine($"Category: {expense.Category}, Description: {expense.Description}, Amount: {expense.Amount:C}, Date: {expense.Date:yyyy-MM-dd}");
            }
        }
    
    
        public static void DeleteExpenseFlow(ExpenseStore expenseStore)
        {
            Console.WriteLine("Enter the description of expense to be deleted: ");
            string? description = Console.ReadLine();
            var expenseToDelete = expenseStore.GetExpenses().FirstOrDefault(e => string.Equals(e.Description, description, StringComparison.OrdinalIgnoreCase));
            if (expenseToDelete != null)
            {
                expenseStore.DeleteExpense(expenseToDelete);
                Console.WriteLine("Expense deleted successfully.");
            }
            else
            {
                Console.WriteLine("Expense not found.");
            }
        }
  }
}
