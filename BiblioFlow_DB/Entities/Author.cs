using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_DB.Entities
{
	public class Author
	{
		public int AuthorId { get; set; }
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string? Bio { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? LastModifiedAt { get; set; }

		public Guid CreatedByUserId { get; set; }
		public User CreatedByUser { get; set; } = null!;
		public Guid? LastModifiedByUserId { get; set; }
		public User LastModifiedByUser { get; set; } = null!;

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
