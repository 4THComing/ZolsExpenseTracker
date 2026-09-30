using ZolsExpenseTracker.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace ZolsExpenseTracker.Api.DTOs.Expenses;

public class ExpenseDTO
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    [EnumDataType(typeof(CategorySelection))]
    public CategorySelection Category { get; set; }

    [Required]
    [StringLength(250, ErrorMessage = "Description cannot exceed 250 characters.")]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Range(0.01, 999999.99, ErrorMessage = "Amount must be greater than zero.")]
    public decimal Amount { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public bool IsIncome { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Vendor name cannot exceed 100 characters.")]
    public string? VendorName { get; set; }

    [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
    public string? Notes { get; set; }
}
