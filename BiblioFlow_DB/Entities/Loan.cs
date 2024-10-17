using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_DB.Entities
{
	public class Loan
	{
		public int LoanId { get; set; }
		public DateTime LoanDate { get; set; }
		public DateTime DueDate { get; set; }
		public DateTime? ReturnDate { get; set; }

		public Guid UserId { get; set; }
		public User User { get; set; } = null!;
		public int LibraryId { get; set; }
		public Library Library { get; set; } = null!;
		public int BookId { get; set; }
		public Book Book { get; set; } = null!;
		public Guid LentByUserId { get; set; }
		public User LentByUser { get; set; } = null!;
	}
}
