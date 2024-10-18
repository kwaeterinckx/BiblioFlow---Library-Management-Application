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
        #endregion
    }
}
