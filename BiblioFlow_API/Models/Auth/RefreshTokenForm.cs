using System.ComponentModel.DataAnnotations;

namespace BiblioFlow_API.Models.Auth
{
    public class RefreshTokenForm
    {
        [Required]
        public string AccessToken { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }
}
