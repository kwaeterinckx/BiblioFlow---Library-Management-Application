using DB = BiblioFlow_DB.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioFlow_DB.Entities;

namespace BiblioFlow_BLL.Entities
{
    public class Author
    {
        public int AuthorId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string? Bio { get; }
        public DateTime CreatedAt { get; }
        public DateTime? LastModifiedAt { get; }
        public Guid CreatedByUserId { get; }
        public Guid? LastModifiedByUserId { get; }

        public Author(string firstName, string lastName, string? bio, DateTime createdAt, DateTime? lastModifiedAt, Guid createdByUserId, Guid? lastModifiedByUserId)
        {
            FirstName = firstName;
            LastName = lastName;
            Bio = bio;
            CreatedAt = createdAt;
            LastModifiedAt = lastModifiedAt;
            CreatedByUserId = createdByUserId;
            LastModifiedByUserId = lastModifiedByUserId;
        }

        internal Author(DB.Author author)
            : this(author.FirstName, author.LastName, author.Bio, author.CreatedAt, author.LastModifiedAt, author.CreatedByUserId, author.LastModifiedByUserId)
        {
            AuthorId = author.AuthorId;
        }
    }
}
