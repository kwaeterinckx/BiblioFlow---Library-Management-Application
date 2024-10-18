using API = BiblioFlow_API.Models.Auth;
using BLL = BiblioFlow_BLL.Entities;

namespace BiblioFlow_API.Mappers
{
    internal static class AuthMapper
    {
        public static API.LoginModel ToLoginModel(this BLL.User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));

            return new API.LoginModel()
            {
                UserId = user.UserId,
                Role = user.Role
            };
        }
    }
}
