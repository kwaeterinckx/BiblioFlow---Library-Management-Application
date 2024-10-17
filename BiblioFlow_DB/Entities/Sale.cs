using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_DB.Entities
{
	public class Sale
	{
		public int SaleId { get; set; }
		public DateTime SaleDate { get; set; }
		public int Quantity { get; set; }
		public decimal TotalPrice { get; set; }

		public Guid UserId { get; set; }
		public User User { get; set; } = null!;
		public int LibraryId { get; set; }
		public Library Library { get; set; } = null!;
		public int BookId { get; set; }
		public Book Book { get; set; } = null!;
        public Guid SoldByUserId { get; set; }
        public User SoldByUser { get; set; } = null!;
    }
}
