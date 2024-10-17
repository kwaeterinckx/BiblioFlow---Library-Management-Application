using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_DB.Entities
{
	public class Reservation
	{
		public int ReservationId { get; set; }
		public DateTime ReservationDate { get; set; }
		public string Status { get; set; } = null!;

		public Guid UserId { get; set; }
		public User User { get; set; } = null!;
		public int LibraryId { get; set; }
		public Library Library { get; set; } = null!;
		public int BookId { get; set; }
		public Book Book { get; set; } = null!;
	}
}
