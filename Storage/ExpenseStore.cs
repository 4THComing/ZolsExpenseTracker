using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using ExpenseInterface.Models;

namespace ExpenseInterface.Storage
{
    public class ExpenseStore
    {
        private readonly string filePath = "Data/expenses.json";
        private List<Expense> expenses = new List<Expense>();

        public void LoadExpenses()
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                expenses = JsonSerializer.Deserialize<List<Expense>>(json) ?? new List<Expense>();
            }
        }

        public void AddExpense(Expense expense)
        {
            if (expense == null)
            {
                throw new ArgumentNullException(nameof(expense));
            }
            expenses.Add(expense);
        }

        public void DeleteExpense(Expense expense)
        {
            if (expense == null)
            {
                throw new ArgumentNullException(nameof(expense));
            }
            expenses.Remove(expense);
        }

        public void SaveExpenses()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(expenses, options);
            File.WriteAllText(filePath, json);
        }

        public IEnumerable<Expense> GetExpenses()
        {
            return expenses;
        }
    }
}