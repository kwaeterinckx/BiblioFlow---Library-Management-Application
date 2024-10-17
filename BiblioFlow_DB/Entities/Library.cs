using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_DB.Entities
{
    public class Library
    {
        public int LibraryId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }

        public Guid CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public Guid? LastModifiedByUserId { get; set; }
        public User LastModifiedByUser { get; set; }

        public ICollection<User> StaffMembers { get; set; }
    }
}
