using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_DB.Entities
{
	public class BookStock
	{
		public int BookStockId { get; set; }
		public string StockType { get; set; } = null!;
		public int Quantity { get; set; }
		public int ReservedStock { get; set; }
		public DateTime LastUpdatedAt { get; set; }

		public Guid LastUpdatedByUserId { get; set; }
		public User LastUpdatedByUser { get; set; } = null!;
		public int BookId { get; set; }
		public Book Book { get; set; } = null!;
		public int LibraryId { get; set; }
		public Library Library { get; set; } = null!;
	}
}
