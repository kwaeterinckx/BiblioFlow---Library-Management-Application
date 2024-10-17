using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_DB.Entities
{
	public class OpeningHours
	{
		public int OpeningHourId { get; set; }
		public int DayOfWeek { get; set; }
		public TimeOnly? OpenTime { get; set; }
		public TimeOnly? CloseTime { get; set; }
		public bool IsClosed { get; set; }
		public DateTime LastModifiedAt { get; set; }
		public Guid LastModifiedById { get; set; }

		public int LibraryId { get; set; }
        public Library Library { get; set; } = null!;
    }
}
