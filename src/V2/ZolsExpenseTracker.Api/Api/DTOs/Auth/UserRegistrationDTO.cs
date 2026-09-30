using System.ComponentModel.DataAnnotations;

namespace ZolsExpenseTracker.Api.DTOs.Auth
{
    public class UserRegistrationDTO
    { 
        [Required]
        public string Username { get; set;} = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}