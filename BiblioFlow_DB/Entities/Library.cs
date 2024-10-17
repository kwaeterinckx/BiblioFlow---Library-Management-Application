using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_DB.Entities
{
	public class Library
	{
		public int LibraryId { get; set; }
		public string Name { get; set; } = null!;
		public string Address { get; set; } = null!;
		public string Phone { get; set; } = null!;
		public string Email { get; set; } = null!;
		public DateTime CreatedAt { get; set; }
		public DateTime? LastModifiedAt { get; set; }

		public Guid CreatedByUserId { get; set; }
		public User CreatedByUser { get; set; } = null!;
		public Guid? LastModifiedByUserId { get; set; }
		public User LastModifiedByUser { get; set; } = null!;

		public ICollection<User> StaffMembers { get; set; } = new Collection<User>();
		public ICollection<OpeningHours> OpeningHours { get; set; } = new Collection<OpeningHours>();
	}
}
