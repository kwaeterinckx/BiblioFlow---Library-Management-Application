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
		public string Title { get; set; }
		public string? Description { get; set; }
		public string Publisher { get; set; }
		public int PublicationYear { get; set; }
		public decimal? Price { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? LastModifiedAt { get; set; }

		public Guid CreatedByUserId { get; set; }
		public User CreatedByUser { get; set; }
		public Guid? LastModifiedByUserId { get; set; }
		public User LastModifiedByUser { get; set; }
	}
}
