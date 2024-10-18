namespace BiblioFlow_API.Models.Auth
{
    public class LoginModel
    {
        public Guid UserId { get; set; }
        public required string Role { get; set; }
    }
}
