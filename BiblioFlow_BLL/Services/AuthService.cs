using DB = BiblioFlow_DB.Entities;

using BCrypt.Net;
using BiblioFlow_BLL.Entities;
using BiblioFlow_BLL.Mappers;
using BiblioFlow_BLL.Repositories;
using BiblioFlow_BLL.Repositories.Entities;
using BiblioFlow_DB.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_BLL.Services
{
    public class AuthService : IAuthRepository<User>
    {
        private readonly BiblioFlowContext _context;
        private readonly IUserRepository<User> _userRepository;

        public AuthService(BiblioFlowContext context, IUserRepository<User> userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public async Task<User?> ValidateUserCredentialsAsync(string email, string password)
        {
            try
            {
                User? user = await _userRepository.GetUserByEmailAsync(email);

                if (user is null || !VerifyPassword(user.Password, password))
                    return null;

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ValidateRefreshTokenAsync(Guid userId, string refreshToken)
        {
            try
            {
                DB.User? user = await _context.Users.Include(u => u.RefreshToken).SingleOrDefaultAsync(u => u.UserId == userId);

                if (user is null || user.RefreshToken.Token != refreshToken || user.RefreshToken.ExpiresAt < DateTime.Now || user.RefreshToken.IsRevoked)
                    return false;

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SetLastLoginTimeAsync(Guid userId)
        {
            try
            {
                DB.User? user = await _context.Users.SingleOrDefaultAsync(u => u.UserId == userId);

                if (user is null)
                    throw new ArgumentNullException(nameof(user));

                user.LastLoginAt = DateTime.Now;

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SaveRefreshTokenAsync(Guid userId, string refreshToken)
        {
            try
            {
                DB.RefreshToken? currentToken = _context.RefreshTokens.SingleOrDefault(ct => ct.UserId == userId);

                if (currentToken is null)
                {
                    RefreshToken token = new RefreshToken(refreshToken, DateTime.Now.AddDays(7), false, DateTime.Now, userId);

                    await _context.RefreshTokens.AddAsync(token.ToRefreshTokenDB());
                }
                else
                {
                    currentToken.Token = refreshToken;
                    currentToken.ExpiresAt = DateTime.Now.AddDays(7);
                    currentToken.CreatedAt = DateTime.Now;
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task RevokeRefreshTokenAsync(Guid userId)
        {
            try
            {
                DB.RefreshToken? refreshToken = await _context.RefreshTokens.SingleOrDefaultAsync(rt => rt.UserId == userId);

                if (refreshToken is not null)
                    _context.RefreshTokens.Remove(refreshToken);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static bool VerifyPassword(string hashedPassword, string password)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
