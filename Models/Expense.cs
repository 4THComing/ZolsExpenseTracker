using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ExpenseInterface;

namespace ExpenseInterface.Models
{
    public class Expense
    {
        [Required]
        public string? Category { get; set; }

        [Required]
        public string? Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than Zero.")]
        public double Amount { get; set; }

        public DateTime Date { get; set; }

        public Expense(string? category, string? description, double amount, DateTime date)
        {
            Category = category;
            Description = description;
            Amount = amount;
            Date = date;

            if (string.IsNullOrWhiteSpace(category))
               throw new ArgumentException("Category is required.");
            if (string.IsNullOrWhiteSpace(description))
               throw new ArgumentException("Description is required.");
            if (amount <= 0)
               throw new ArgumentException("Amount must be higher than 0.00");
            if (date == DateTime.MinValue)
               throw new ArgumentException("Date is required.");
        }
    }
}