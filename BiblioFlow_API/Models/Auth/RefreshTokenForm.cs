using System.ComponentModel.DataAnnotations;

namespace BiblioFlow_API.Models.Auth
{
    public class RefreshTokenForm
    {
        [Required]
        public required string AccessToken { get; set; }

        [Required]
        public required string RefreshToken { get; set; }
    }
}
