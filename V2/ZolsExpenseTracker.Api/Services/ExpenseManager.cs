using System;
using System.Collections.Generic;
using ZolsExpenseTracker.Api.Models;
using System.Linq;

namespace ZolsExpenseTracker.Api.Services
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

        public IEnumerable<Expense> GetExpensesByCategory(CategorySelection category, IEnumerable<Expense> expenses)
        {
            var filteredExpenses = new List<Expense>();
            foreach (var expense in expenses)
            {
                if (expense.Category == category)
                {
                    filteredExpenses.Add(expense);
                }
            }
            return filteredExpenses;
        }

        public IEnumerable<Expense> GetExpensesByDescription(string description, IEnumerable<Expense> expenses)
        {
             var filteredExpenses = new List<Expense>();
            foreach (var expense in expenses)
            {
                if (expense.Description == description)
                {
                    filteredExpenses.Add(expense);
                }
            }
            return filteredExpenses;
        }

        public IEnumerable<Expense> GetExpensesByDate(DateTime date, IEnumerable<Expense> expenses)
        {
            var filteredExpenses = new List<Expense>();
            foreach (var expense in expenses)
            {
                if (expense.Date.Date == date.Date)
                {
                    filteredExpenses.Add(expense);
                }
            }
            return filteredExpenses;
        }

        public IEnumerable<Expense> GetExpensesAboveAmount(double amount, IEnumerable<Expense> expenses)
        {
            var filteredExpenses = new List<Expense>();
            foreach (var expense in expenses)
            {
                if (expense.Amount > amount)
                {
                    filteredExpenses.Add(expense);
                }
            }
            return filteredExpenses;
        }

        public IEnumerable<Expense> GetExpensesBelowAmount(double amount, IEnumerable<Expense> expenses)
        {
            var filteredExpenses = new List<Expense>();
            foreach (var expense in expenses)
            {
                if (expense.Amount < amount)
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

        public double GetHighestExpense(IEnumerable<Expense> expenses)
        {
            double HighestExpense = double.MinValue;
            for (int i = 0; i < expenses.Count(); i++)
            {
                var expense = expenses.ElementAt(i);
                if (expense.Amount > HighestExpense)
                {
                    HighestExpense = expense.Amount;
                }
            }
            return HighestExpense;
        }

        public double GetLowestExpense(IEnumerable<Expense> expenses)
        {
            double LowestExpense = double.MaxValue;
            for (int i = 0; i < expenses.Count(); i++)
            {
                var expense = expenses.ElementAt(i);
                if (expense.Amount < LowestExpense)
                {
                    LowestExpense = expense.Amount;
                }
            } 
            return LowestExpense;
        }

        public double GetAverageExpense(IEnumerable<Expense> expenses)
        {
            double total = 0;
            int count = 0;
            for (int i = 0; i < expenses.Count(); i++)
            {
                var expense = expenses.ElementAt(i);
                total += expense.Amount;
                count++;
            }
            return count > 0 ? total / count : 0;
        }
    }
}