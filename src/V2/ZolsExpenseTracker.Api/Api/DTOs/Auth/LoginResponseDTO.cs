using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace ZolsExpenseTracker.Api.DTOs.Auth
{
    public class LoginResponseDTO
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;
        
        [Required]
        public DateTime ExpirationDate { get; set; } = DateTime.UtcNow.AddDays(7);

       // public  JWTToken { get; set; }
    }
}