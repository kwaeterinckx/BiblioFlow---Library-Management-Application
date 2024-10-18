using DB = BiblioFlow_DB.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioFlow_DB.Entities;

namespace BiblioFlow_BLL.Entities
{
    public class OpeningHours
    {
        public int OpeningHourId { get; }
        public int DayOfWeek { get; }
        public TimeOnly? OpenTime { get; }
        public TimeOnly? CloseTime { get; }
        public bool IsClosed { get; }
        public DateTime LastModifiedAt { get; }
        public Guid LastModifiedById { get; }
        public int LibraryId { get; }

        public OpeningHours(int dayOfWeek, TimeOnly? openTime, TimeOnly? closeTime, bool isClosed, DateTime lastModifiedAt, Guid lastModifiedById, int libraryId)
        {
            DayOfWeek = dayOfWeek;
            OpenTime = openTime;
            CloseTime = closeTime;
            IsClosed = isClosed;
            LastModifiedAt = lastModifiedAt;
            LastModifiedById = lastModifiedById;
            LibraryId = libraryId;
        }

        internal OpeningHours(DB.OpeningHours openingHours)
            : this(openingHours.DayOfWeek, openingHours.OpenTime, openingHours.CloseTime, openingHours.IsClosed, openingHours.LastModifiedAt, openingHours.LastModifiedById, openingHours.LibraryId)
        {
            OpeningHourId = openingHours.OpeningHourId;
        }
    }
}
