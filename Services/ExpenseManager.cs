using System;
using System.Collections.Generic;
using ExpenseInterface.Models;

namespace ExpenseInterface.Services
{
    public class ExpenseManager
    {
        public double GetTotalExpenses(IEnumerable<Expense> expenses)
        {
            double total = 0.00;
            foreach (var expense in expenses)
            {
                total += expense.Amount;
            }
            return total;
        }

        public IEnumerable<Expense> FilterByCategory(string category, IEnumerable<Expense> expenses)
        {
            var filteredExpenses = new List<Expense>();
            foreach (var expense in expenses)
            {
                if (expense.Category.ToString() == category)
                {
                    filteredExpenses.Add(expense);
                }
            }
            return filteredExpenses;
        }

        public double GetMonthlyTotalExpenses(int month, int year, IEnumerable<Expense> expenses)
        {
            double monthlyTotal = 0;
            foreach (var expense in expenses)
            {
                if (expense.Date.Month == month && expense.Date.Year == year)
                {
                    monthlyTotal += expense.Amount;
                }
            }
            return monthlyTotal;
        }
    }
}