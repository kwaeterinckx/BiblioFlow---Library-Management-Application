using DB = BiblioFlow_DB.Entities;

using BiblioFlow_BLL.Entities;
using BiblioFlow_BLL.Mappers;
using BiblioFlow_BLL.Repositories;
using BiblioFlow_DB.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_BLL.Services
{
    public class UserService : IUserRepository<User>
    {
        private readonly BiblioFlowContext _context;

        public UserService(BiblioFlowContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            try
            {
                DB.User? user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);

                return user?.ToUserBLL();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
