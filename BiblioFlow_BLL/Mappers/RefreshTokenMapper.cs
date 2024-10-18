using BLL = BiblioFlow_BLL.Entities;
using DB = BiblioFlow_DB.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_BLL.Mappers
{
    internal static class RefreshTokenMapper
    {
        #region To DataBase
        public static DB.RefreshToken ToRefreshTokenDB(this BLL.RefreshToken refreshToken)
        {
            if (refreshToken is null) throw new ArgumentNullException(nameof(refreshToken));

            return new DB.RefreshToken()
            {
                Token = refreshToken.Token,
                ExpiresAt = refreshToken.ExpiresAt,
                IsRevoked = refreshToken.IsRevoked,
                CreatedAt = refreshToken.CreatedAt,
                UserId = refreshToken.UserId
            };
        }
        #endregion
    }
}
