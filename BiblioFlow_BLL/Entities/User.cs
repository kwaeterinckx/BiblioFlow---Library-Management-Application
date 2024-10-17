using DB = BiblioFlow_DB.Entities;

using BiblioFlow_BLL.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioFlow_DB.Entities;
using BiblioFlow_DB.Migrations;
using System.Data;

namespace BiblioFlow_BLL.Entities
{
    public class User : IUser
    {
        public Guid UserId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }
        public string Role { get; }
        public bool IsActif { get; }
        public DateTime? LastLoginAt { get; }
        public DateTime CreatedAt { get; }
        public DateTime? LastModifiedAt { get; }
        public Guid? CreatedByUserId { get; }
        public Guid? LastModifiedByUserId { get; }
        public int? LibraryId { get; }

        public User(string firstName, string lastName, string email, string password, string role, bool isActif, DateTime? lastLoginAt, DateTime createdAt, DateTime? lastModifiedAt, Guid? createdByUserId, Guid? lastModifiedByUserId, int? libraryId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Role = role;
            IsActif = isActif;
            LastLoginAt = lastLoginAt;
            CreatedAt = createdAt;
            LastModifiedAt = lastModifiedAt;
            CreatedByUserId = createdByUserId;
            LastModifiedByUserId = lastModifiedByUserId;
            LibraryId = libraryId;
        }
        internal User(DB.User user)
            : this(user.FirstName, user.LastName, user.Email, user.Password, user.Role, user.IsActif, user.LastLoginAt, user.CreatedAt, user.LastModifiedAt, user.CreatedByUserId, user.LastModifiedByUserId, user.LibraryId)
        {
            UserId = user.UserId;
        }
    }
}
