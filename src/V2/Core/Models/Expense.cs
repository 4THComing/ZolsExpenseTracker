using System.ComponentModel.DataAnnotations;
using ZolsExpenseTracker.Core.Enums;

namespace ZolsExpenseTracker.Core.Models
{
   public class Expense
   {
      [Key]
      public Guid Id { get; set; } = Guid.NewGuid();
      
      [Required]
      public CategorySelection Category { get; set; }

      [Required, MaxLength(200)]
      public string Description { get; set; } = string.Empty;

      [Range(0.01, 999999.99, ErrorMessage = "Amount must be greater than Zero.")]
      public decimal Amount { get; set; }

      [Required] 
      public DateTime Date { get; set; } = DateTime.UtcNow;

   }
}