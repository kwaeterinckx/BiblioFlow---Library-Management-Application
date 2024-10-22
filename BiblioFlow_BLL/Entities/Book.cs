using DB = BiblioFlow_DB.Entities;

using BiblioFlow_BLL.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Diagnostics;
using BiblioFlow_BLL.Mappers;

namespace BiblioFlow_BLL.Entities
{
    public class Book : IBook
    {
        public int BookId { get; }
        public string? ISBN { get; }
        public string Title { get; }
        public string? Description { get; }
        public string Publisher { get; }
        public int PublicationYear { get; }
        public decimal? Price { get; }
        public DateTime CreatedAt { get; }
        public DateTime? LastModifiedAt { get; }
        public Guid CreatedByUserId { get; }
        public Guid? LastModifiedByUserId { get; }
        public ICollection<Author> Authors { get; }
        public ICollection<Category> Categories { get; }

        public Book(string? isbn, string title, string? description, string publisher, int publicationYear, decimal? price, DateTime createdAt, DateTime? lastModifiedAt, Guid createdByUserId, Guid? lastModifiedByUserId, ICollection<Author> authors, ICollection<Category> categories)
        {
            ISBN = isbn;
            Title = title;
            Description = description;
            Publisher = publisher;
            PublicationYear = publicationYear;
            Price = price;
            CreatedAt = createdAt;
            LastModifiedAt = lastModifiedAt;
            CreatedByUserId = createdByUserId;
            LastModifiedByUserId = lastModifiedByUserId;
            Authors = authors;
            Categories = categories;
        }
        internal Book(DB.Book book)
            : this(book.ISBN, book.Title, book.Description, book.Publisher, book.PublicationYear, book.Price, book.CreatedAt, book.LastModifiedAt, book.CreatedByUserId, book.LastModifiedByUserId, book.Authors.Select(a => a.ToAuthorBLL()).ToList(), book.Categories.Select(c => c.ToCategoryBLL()).ToList())
        {
            BookId = book.BookId;
        }
    }
}
