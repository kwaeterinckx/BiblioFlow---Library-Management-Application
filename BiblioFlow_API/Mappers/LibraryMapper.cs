using API = BiblioFlow_API.Models.Library;
using BLL = BiblioFlow_BLL.Entities;

namespace BiblioFlow_API.Mappers
{
    public static class LibraryMapper
    {
        #region To Model
        public static API.LibraryModel ToLibraryModel(this BLL.Library library)
        {
            if (library is null) throw new ArgumentNullException(nameof(library));

            return new API.LibraryModel()
            {
                LibraryId = library.LibraryId,
                Name = library.Name,
                Address = library.Address,
                Phone = library.Phone,
                Email = library.Email,
                OpeningHours = library.OpeningHours.Select(oh => oh.ToOpeningHoursModel()).ToList()
            };
        }

        public static API.OpeningHoursModel ToOpeningHoursModel(this BLL.OpeningHours openingHours)
        {
            if (openingHours is null) throw new ArgumentNullException(nameof(openingHours));

            return new API.OpeningHoursModel()
            {
                OpeningHourId = openingHours.OpeningHourId,
                DayOfWeek = openingHours.DayOfWeek,
                OpenTime = openingHours.OpenTime,
                CloseTime = openingHours.CloseTime,
                IsClosed = openingHours.IsClosed
            };
        }
        #endregion

        #region To BLL
        public static BLL.Library ToNewLibraryBLL(this API.LibraryForm library, Guid createdByUserId)
        {
            if (library is null) throw new ArgumentNullException(nameof(library));

            return new BLL.Library(library.Name, library.Address, library.Phone, library.Email, DateTime.Now, null, createdByUserId, null);
        }
        public static BLL.Library ToUpdateLibraryBLL(this API.LibraryForm library, Guid lastModifiedByUserId)
        {
            if (library is null) throw new ArgumentNullException(nameof(library));

            return new BLL.Library(library.Name, library.Address, library.Phone, library.Email, DateTime.Now, DateTime.Now, lastModifiedByUserId, lastModifiedByUserId);
        }
        public static BLL.Library ToUpdateOpeningHoursBLL(this API.LibraryOpeningHoursForm library, Guid lastModifiedByUserId)
        {
            if (library is null) throw new ArgumentNullException(nameof(library));

            return new BLL.Library(library.OpeningHours.Select(oh=>oh.ToOpeningHoursBLL(lastModifiedByUserId)).ToList());
        }
        public static BLL.OpeningHours ToOpeningHoursBLL(this API.OpeningHoursForm openingHours, Guid lastModifiedByUserId)
        {
            if (openingHours is null) throw new ArgumentNullException(nameof(openingHours));

            TimeOnly? openTime = (openingHours.OpenTime is null) ? null : TimeOnly.Parse(openingHours.OpenTime);
            TimeOnly? closeTime = (openingHours.CloseTime is null) ? null : TimeOnly.Parse(openingHours.CloseTime);

            return new BLL.OpeningHours(openingHours.DayOfWeek, openTime, closeTime, openingHours.IsClosed, DateTime.Now, lastModifiedByUserId);
        }
        #endregion
    }
}
