using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseInterface.Models;
using ExpenseInterface.Services;
using ExpenseInterface.Storage;

namespace ExpenseInterface
{
    class Program
    {
        private  ExpenseStore expenseStore = new ExpenseStore();
        private ExpenseManager expenseManager = new ExpenseManager();

        public static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        public void Run()
        {
            ShowMenu();
        }

        public void ShowMenu()
        {
            bool running = true;
            while (running)
            {

                Console.WriteLine("--Expense Tracker Menu--");
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. View Expenses");
                Console.WriteLine("3. View Total Expenses"); 
                Console.WriteLine("4. Delete Expense"); 
                Console.WriteLine("5. Exit");

                Console.Write("Select an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                       AddExpenseFlow();
                       break;
                    case "2":
                       ViewExpenseFlow();
                       break;
                    case "3":
                       var total = expenseManager.GetTotalExpenses(expenseStore.GetExpenses());
                       Console.WriteLine($"Total Expenses: {total:C}");
                       break;
                    case "4":
                       DeleteExpenseFlow();
                       break;   
                    case "5":
                       Console.WriteLine("Exiting...");
                       running = false;
                       break;
                    default:
                       Console.WriteLine("Invalid option. Please try again.");
                       break;
                }
            }
        }

        public void AddExpenseFlow()
        { 
            string? category = string.Empty;
            string? description = string.Empty;
            double amount = 0.00;
            DateTime date = DateTime.Now;
                
            Console.Write("1. Enter Expense Category: ");
            category = Console.ReadLine();
            while (true)
            {
                bool InvalidCategory = string.IsNullOrWhiteSpace(category) || category.Any(char.IsDigit);
                if (InvalidCategory)
                {
                   Console.WriteLine("Category is required. Please enter a valid category.");
                   Console.Write("1. Enter Expense Category: ");
                   category = Console.ReadLine();
                }
               else
               {
                   break;
               }
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
            date = DateTime.TryParse(Console.ReadLine(), out date) ? date : DateTime.Now;
            while (true)
            {
                bool InvalidDate = date == DateTime.Now;
                if (InvalidDate)
                {
                    Console.WriteLine("Invalid date, Please enter a valid date in the format YYYY-MM-DD");
                    Console.Write("5. Enter Expense Date: ");
                    date = DateTime.TryParse(Console.ReadLine(), out date) ? date : DateTime.Now;
                }
                else
                {
                    break;
                }
            }

            var expense = new Expense(category, description, amount, date);
            expenseStore.AddExpense(expense);
        }

        public void ViewExpenseFlow()
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
        public void DeleteExpenseFlow()
        {
            Console.WriteLine("Enter the description of expense to be deleted: ");
            string? description = Console.ReadLine();
            var expenseToDelete = expenseStore.GetExpenses().FirstOrDefault(e => e.Description.Equals(description, StringComparison.OrdinalIgnoreCase));
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

