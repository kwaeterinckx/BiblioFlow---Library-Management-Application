using System.ComponentModel.DataAnnotations;

namespace BiblioFlow_API.Models.Auth
{
    public class LoginForm
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
