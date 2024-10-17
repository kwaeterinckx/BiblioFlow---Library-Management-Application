using BCrypt.Net;
using BiblioFlow_BLL.Entities;
using BiblioFlow_BLL.Repositories;
using BiblioFlow_BLL.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_BLL.Services
{
    public class AuthService : IAuthRepository<User>
    {
        private readonly IUserRepository<User> _userRepository;

        public AuthService(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> ValidateUserCredentialsAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user is null || !VerifyPassword(user.Password, password)) return null;

            return user;
        }

        public Task SaveRefreshTokenAsync(Guid userId, string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task RevokeRefreshTokenAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        private bool VerifyPassword(string hashedPassword, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
