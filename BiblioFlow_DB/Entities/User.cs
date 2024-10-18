using System;
using System.Collections.Generic;
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

		public RefreshToken RefreshToken { get; set; } = null!;

		public ICollection<User> CreatedUsers { get; set; } = new List<User>();
		public ICollection<User> LastModifiedUsers { get; set; } = new List<User>();
		public ICollection<Library> CreatedLibraries { get; set; } = new List<Library>();
		public ICollection<Library> LastModifiedLibraries { get; set; } = new List<Library>();
		public ICollection<Book> CreatedBooks { get; set; } = new List<Book>();
		public ICollection<Book> LastModifiedBooks { get; set; } = new List<Book>();
		public ICollection<Author> CreatedAuthors { get; set; } = new List<Author>();
		public ICollection<Author> LastModifiedAuthors { get; set; } = new List<Author>();
		public ICollection<Category> CreatedCategories { get; set; } = new List<Category>();
		public ICollection<Category> LastModifiedCategories { get; set; } = new List<Category>();
		public ICollection<BookStock> LastUpdatedBookStock { get; set; } = new List<BookStock>();
		public ICollection<Sale> BoughtBooks { get; set; } = new List<Sale>();
		public ICollection<Loan> RentedBooks { get; set; } = new List<Loan>();
		public ICollection<Sale> SoldBooks { get; set; } = new List<Sale>();
		public ICollection<Loan> LentBooks { get; set; } = new List<Loan>();
		public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
		public ICollection<Address> Addresses { get; set; } = new List<Address>();
	}
}
