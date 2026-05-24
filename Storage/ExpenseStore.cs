using System;
using System.Collections.Generic;
using ExpenseInterface.Models;

namespace ExpenseInterface.Storage
{
    public class ExpenseStore
    {
        private List<Expense> expenses = new List<Expense>();
        
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

        public IEnumerable<Expense> GetExpenses()
        {
            return expenses;
        }
    }
}