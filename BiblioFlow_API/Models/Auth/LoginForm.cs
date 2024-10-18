using System.ComponentModel.DataAnnotations;

namespace BiblioFlow_API.Models.Auth
{
    public class LoginForm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
