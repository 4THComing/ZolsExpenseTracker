using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseInterface.Services;
using ExpenseInterface.Storage;
using ExpenseInterface.Models;
using ExpenseInterface.ProjectUI.Helper;

namespace ExpenseInterface.ProjectUI
{
    public class ExpenseUI
    {
        public static void DisplayExpenses(IEnumerable<Expense> expenses)
        {

            foreach (var expense in expenses)
            {
                Console.WriteLine($"Category: ID {expense.Id} {expense.Category}, Description: {expense.Description}, Amount: {expense.Amount:C}, Date: {expense.Date:yyyy-MM-dd}");
            }
        }
        public static void AddExpenseFlow(ExpenseStore expenseStore)
        {
            CategorySelection category = InputHelper.GetValidCategoryInput();

            string description = InputHelper.GetValidDescriptionInput();

            double amount = InputHelper.GetValidAmountInput();

            DateTime date = InputHelper.GetValidDateInput();

            try
            {
                var expense = new Expense(category, description, amount, date);
                expenseStore.AddExpense(expense);
                Console.WriteLine("Expense added successfully.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error adding expense: {ex.Message}");
            }

            expenseStore.SaveExpenses();
            Console.WriteLine("Expense saved successfully.");
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

                Console.WriteLine($"{i + 1}. Category: ID {expense.Id} {expense.Category}, Description: {expense.Description}, Amount: {expense.Amount:C}, Date: {expense.Date:yyyy-MM-dd}");
            }

            Console.WriteLine("Enter the number of the expense you want to update: ");

            var selectedExpense = Console.ReadLine();

            if (selectedExpense == null || !int.TryParse(selectedExpense, out int expenseIndex))
            {
                Console.WriteLine("Invalid expense number.");
                return;
            }

            if (expenseIndex < 1 || expenseIndex > expenses.Count)
            {
                Console.WriteLine("Expense number out of bounds.");
                return;
            }

            var expenseToUpdate = expenses[expenseIndex - 1];

            Console.WriteLine("Current Expense Details: ");
            Console.WriteLine($"ID: {expenseToUpdate.Id}");
            Console.WriteLine($"Category: {expenseToUpdate.Category}");
            Console.WriteLine($"Description: {expenseToUpdate.Description}");
            Console.WriteLine($"Amount: {expenseToUpdate.Amount:C}");
            Console.WriteLine($"Date: {expenseToUpdate.Date:yyyy-MM-dd}");

            expenseToUpdate.Category = InputHelper.GetValidCategoryInput();

            expenseToUpdate.Description = InputHelper.GetValidDescriptionInput();

            expenseToUpdate.Amount = InputHelper.GetValidAmountInput();

            expenseToUpdate.Date = InputHelper.GetValidDateInput();

            expenseStore.SaveExpenses();
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

            DisplayExpenses(expenses);
        }

        public static void FilterExpensesByCategory(ExpenseStore expenseStore)
        {
            var expenses = expenseStore.GetExpenses();
            if (!expenses.Any())
            {
                Console.WriteLine("No expenses found to filter.");
                return;
            }
            Console.WriteLine("Select a category to filter by: ");

            CategorySelection filteredCategory = InputHelper.GetValidCategoryInput();

            var filteredExpenses = new ExpenseManager().GetExpensesByCategory(filteredCategory, expenses);

            Console.WriteLine($"Expenses in category: {filteredCategory}: ");

            if (!filteredExpenses.Any())
            {
                Console.WriteLine($"No expenses found in category {filteredCategory}.");
                return;
            }

            DisplayExpenses(filteredExpenses);
        }

        public static void FilterExpensesByDescription(ExpenseStore expenseStore)
        {
            var expenses = expenseStore.GetExpenses();
            if (!expenses.Any())
            {
                Console.WriteLine("No expenses found. ");
                return;
            }

            Console.WriteLine("Select a description to filter by: ");

            string filteredDescription = InputHelper.GetValidDescriptionInput();

            var filteredExpenses = new ExpenseManager().GetExpensesByDescription(filteredDescription, expenses);

            Console.WriteLine($"Expense in Description: {filteredDescription}");

            if (!filteredExpenses.Any())
            {
                Console.WriteLine($"No expenses found in category {filteredDescription}.");
                return;
            }

            DisplayExpenses(filteredExpenses);
        }

        public static void FilterExpensesByDate(ExpenseStore expenseStore)
        {
            var expenses = expenseStore.GetExpenses();
            if (!expenses.Any())
            {
                Console.WriteLine("No expenses found to filter.");
                return;
            }
            Console.WriteLine("Enter a date to filter by (yyyy-MM-dd): ");

            DateTime filteredDate = InputHelper.GetValidDateInput();

            var filteredExpenses = new ExpenseManager().GetExpensesByDate(filteredDate, expenses);

            Console.WriteLine($"Expenses on date {filteredDate:yyyy-MM-dd}: ");

            if (!filteredExpenses.Any())
            {
                Console.WriteLine($"No expenses found on date {filteredDate:yyyy-MM-dd}.");
                return;
            }

            DisplayExpenses(filteredExpenses);
        }

        public static void FilterExpensesByAmount(ExpenseStore expenseStore)
        {
            var expenses = expenseStore.GetExpenses();
            if (!expenses.Any())
            {
                Console.WriteLine("No expenses found to filter.");
                return;
            }
            Console.WriteLine("Choose a filter option: 1. Filter by amount above 2. Filter by amount below");
            var choice = Console.ReadLine();
            while (choice != "1" && choice != "2")
            {
                Console.WriteLine("Invalid choice, Please select a valid filter option from the list.");
                Console.WriteLine("Choose a filter option: 1. Filter by amount above 2. Filter by amount below");
                choice = Console.ReadLine();
            }

            if (choice == "1")
            {
                Console.WriteLine("Choose to filter an amount above : ");

                double filteredAmount = InputHelper.GetValidAmountInput();

                var filteredExpenses = new ExpenseManager().GetExpensesAboveAmount(filteredAmount, expenses);

                Console.WriteLine($"Expenses above {filteredAmount:C}: ");

                if (!filteredExpenses.Any())
                {
                    Console.WriteLine($"No expenses found above {filteredAmount:C}.");
                    return;
                }

                DisplayExpenses(filteredExpenses);
            }
            if (choice == "2")
            {
                Console.WriteLine("Choose to filter an amount below : ");

                double filteredAmount = InputHelper.GetValidAmountInput();

                var filteredExpenses = new ExpenseManager().GetExpensesBelowAmount(filteredAmount, expenses);

                Console.WriteLine($"Expenses below {filteredAmount:C}: ");

                if (!filteredExpenses.Any())
                {
                    Console.WriteLine($"No expenses found below {filteredAmount:C}.");
                    return;
                }

                DisplayExpenses(filteredExpenses);
            }
        }

        public static void DeleteExpenseFlow(ExpenseStore expenseStore)
        {
            List<Expense> expenses = expenseStore.GetExpenses().ToList();

            if (!expenses.Any())
            {
                Console.WriteLine("No expenses found.");
                return;
            }

            Console.WriteLine("Expenses:");

            for (int i = 0; i < expenses.Count; i++)
            {
                var expense = expenses[i];

                Console.WriteLine($"{i + 1}. {expense.Description} - {expense.Amount:C}");
            }

            int expenseIndex = InputHelper.GetExpenseToDelete(expenses.Count);

            var expenseToDelete = expenses[expenseIndex - 1];

            expenseStore.DeleteExpense(expenseToDelete);

            expenseStore.SaveExpenses();

            Console.WriteLine("Expense deleted successfully.");
        }
    }
}
