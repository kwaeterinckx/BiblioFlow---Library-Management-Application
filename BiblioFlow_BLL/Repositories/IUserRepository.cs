using BiblioFlow_BLL.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_BLL.Repositories
{
    public interface IUserRepository<TUser> where TUser : IUser
    {
        Task<TUser?> GetUserByEmailAsync(string email);
    }
}
