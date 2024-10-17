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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsActif { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }

        public Guid? CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public Guid? LastModifiedByUserId { get; set; }
        public User LastModifiedByUser { get; set; }

        public int? LibraryId { get; set; }
        public Library Library { get; set; }

        public ICollection<User> CreatedUsers { get; set; }
        public ICollection<User> LastModifiedUsers { get; set; }
        public ICollection<Library> CreatedLibraries { get; set; }
        public ICollection<Library> LastModifiedLibraries { get; set; }
    }
}
