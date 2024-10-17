using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_DB.Entities
{
	public class Book
	{
		public int BookId { get; set; }
		public string? ISBN { get; set; }
		public string Title { get; set; } = null!;
		public string? Description { get; set; }
		public string Publisher { get; set; } = null!;
		public int PublicationYear { get; set; }
		public decimal? Price { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? LastModifiedAt { get; set; }

		public Guid CreatedByUserId { get; set; }
		public User CreatedByUser { get; set; } = null!;
		public Guid? LastModifiedByUserId { get; set; }
		public User LastModifiedByUser { get; set; } = null!;

		public ICollection<Author> Authors { get; set; } = new List<Author>();
		public ICollection<Category> Categories { get; set; } = new List<Category>();
		public ICollection<BookStock> BookStocks { get; set; } = new List<BookStock>();
		public ICollection<Sale> SoldBooks { get; set; } = new List<Sale>();
		public ICollection<Loan> LentBooks { get; set; } = new List<Loan>();
		public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
	}
}
