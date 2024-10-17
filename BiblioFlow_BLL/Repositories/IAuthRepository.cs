using BiblioFlow_BLL.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_BLL.Repositories
{
    public interface IAuthRepository<TUser> where TUser : IUser
    {
        Task<TUser?> ValidateUserCredentialsAsync(string email, string password);

        Task SaveRefreshTokenAsync(Guid userId, string refreshToken);

        Task RevokeRefreshTokenAsync(Guid userId);
    }
}
