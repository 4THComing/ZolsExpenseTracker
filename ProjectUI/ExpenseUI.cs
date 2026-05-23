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

        public static void UpdateExpenseFlow()
        {
                Console.WriteLine("Update Expense feature is currently under development. Please check back later.");
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
