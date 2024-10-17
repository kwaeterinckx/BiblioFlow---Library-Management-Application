using BLL = BiblioFlow_BLL.Entities;
using DB = BiblioFlow_DB.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_BLL.Mappers
{
    public static class UserMapper
    {
        #region To BLL
        public static BLL.User ToUserBLL(this DB.User user)
        {
            return new BLL.User(user);
        }
        #endregion
    }
}
