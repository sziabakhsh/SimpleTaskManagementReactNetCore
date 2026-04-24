using System.ComponentModel.DataAnnotations;

namespace TaskManagement.DTOs.Account
{
    public class LoginDto
    {

        [Required]
        public string Username { get; set; }=string.Empty;
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
