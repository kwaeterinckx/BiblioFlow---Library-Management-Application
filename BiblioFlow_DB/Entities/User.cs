using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_DB.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = null!;  
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public bool IsActif { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }

        public Guid? CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; } = null!;
        public Guid? LastModifiedByUserId { get; set; }
        public User LastModifiedByUser { get; set; } = null!;

        public int? LibraryId { get; set; }
        public Library Library { get; set; } = null!;

        public ICollection<User> CreatedUsers { get; set; } = new Collection<User>();
        public ICollection<User> LastModifiedUsers { get; set; } = new Collection<User>();
		public ICollection<Library> CreatedLibraries { get; set; } = new Collection<Library>();
		public ICollection<Library> LastModifiedLibraries { get; set; } = new Collection<Library>();
		public ICollection<Book> CreatedBooks { get; set; } = new Collection<Book>();
		public ICollection<Book> LastModifiedBooks { get; set; } = new Collection<Book>();
	}
}
