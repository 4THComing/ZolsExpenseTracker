using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Zols.ExpenseTracker.V1.Console.Models
{
   public class Expense
   {
      public Guid Id { get; set; }

      public CategorySelection Category { get; set; }

      public string? Description { get; set; }

      [Range(0.01, 99999999.99, ErrorMessage = "Amount must be greater than Zero.")]
      public decimal Amount { get; set; }

      public DateTime Date { get; set; } = DateTime.UtcNow;

      public Expense()
      {

      }
      public Expense(CategorySelection category, string? description, decimal amount, DateTime date)
      {
         Id = Guid.NewGuid();
         Category = category;
         Description = description;
         Amount = amount;
         Date = date;

         if (category == default(CategorySelection))
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