using BLL = BiblioFlow_BLL.Entities;
using DB = BiblioFlow_DB.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_BLL.Mappers
{
    internal static class LibraryMapper
    {
        #region To BLL
        public static BLL.Library ToLibraryBLL(this DB.Library library)
        {
            if (library is null) throw new ArgumentNullException(nameof(library));

            return new BLL.Library(library);
        }

        public static BLL.OpeningHours ToOpeningHoursBLL(this DB.OpeningHours openingHours)
        {
            if (openingHours is null) throw new ArgumentNullException(nameof(openingHours));

            return new BLL.OpeningHours(openingHours);
        }
        #endregion

        #region To DataBase
        public static DB.Library ToLibraryDB(this BLL.Library library)
        {
            if (library is null) throw new ArgumentNullException(nameof(library));

            return new DB.Library()
            {
                Name = library.Name,
                Address = library.Address,
                Phone = library.Phone,
                Email = library.Email,
                CreatedAt = library.CreatedAt,
                CreatedByUserId = library.CreatedByUserId,
                LastModifiedAt = library.LastModifiedAt,
                LastModifiedByUserId = library.LastModifiedByUserId
            };
        }
        #endregion
    }
}
