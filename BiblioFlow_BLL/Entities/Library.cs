using DB = BiblioFlow_DB.Entities;

using BiblioFlow_BLL.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioFlow_DB.Entities;
using System.Collections.ObjectModel;
using System.Net;
using System.Numerics;
using BiblioFlow_BLL.Mappers;

namespace BiblioFlow_BLL.Entities
{
    public class Library : ILibrary
    {
        public int LibraryId { get; }
        public string Name { get; }
        public string Address { get; }
        public string Phone { get; }
        public string Email { get; }
        public DateTime CreatedAt { get; }
        public DateTime? LastModifiedAt { get; }
        public Guid CreatedByUserId { get; }
        public Guid? LastModifiedByUserId { get; }
        public ICollection<OpeningHours> OpeningHours { get; }

        public Library(string name, string address, string phone, string email, DateTime createdAt, DateTime? lastModifiedAt, Guid createdByUserId, Guid? lastModifiedByUserId)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
            CreatedAt = createdAt;
            LastModifiedAt = lastModifiedAt;
            CreatedByUserId = createdByUserId;
            LastModifiedByUserId = lastModifiedByUserId;
            OpeningHours = new List<OpeningHours>();
        }
        public Library(ICollection<OpeningHours> openingHours)
        {
            OpeningHours = openingHours;
        }
        internal Library(DB.Library library)
            : this(library.Name, library.Address, library.Phone, library.Email, library.CreatedAt, library.LastModifiedAt, library.CreatedByUserId, library.LastModifiedByUserId)
        {
            LibraryId = library.LibraryId;
            OpeningHours = library.OpeningHours.Select(oh => oh.ToOpeningHoursBLL()).ToList();
        }
    }
}
