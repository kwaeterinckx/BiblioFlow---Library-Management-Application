using BLL = BiblioFlow_BLL.Entities;
using DB = BiblioFlow_DB.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_BLL.Mappers
{
    internal static class BookMapper
    {
        #region To BLL
        public static BLL.Book ToBookBLL(this DB.Book book)
        {
            if (book is null) throw new ArgumentNullException(nameof(book));

            return new BLL.Book(book);
        }
        public static BLL.Author ToAuthorBLL(this DB.Author author)
        {
            if (author is null) throw new ArgumentNullException(nameof(author));

            return new BLL.Author(author);
        }
        public static BLL.Category ToCategoryBLL(this DB.Category category)
        {
            if (category is null) throw new ArgumentNullException(nameof(category));

            return new BLL.Category(category);
        }
        #endregion

        #region To DataBase
        public static DB.Book ToBookDB(this BLL.Book book)
        {
            if (book is null) throw new ArgumentNullException(nameof(book));

            return new DB.Book()
            {
                ISBN = book.ISBN,
                Title = book.Title,
                Description = book.Description,
                Publisher = book.Publisher,
                PublicationYear = book.PublicationYear,
                Price = book.Price,
                CreatedAt = book.CreatedAt,
                CreatedByUserId = book.CreatedByUserId,
                LastModifiedAt = book.LastModifiedAt,
                LastModifiedByUserId = book.LastModifiedByUserId,
                Authors = book.Authors.Select(a => a.ToAuthorDB()).ToList(),
                Categories = book.Categories.Select(c => c.ToCategoryDB()).ToList()
            };
        }
        public static DB.Author ToAuthorDB(this BLL.Author author)
        {
            if (author is null) throw new ArgumentNullException(nameof(author));

            return new DB.Author()
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                Bio = author.Bio,
                CreatedAt = author.CreatedAt,
                CreatedByUserId = author.CreatedByUserId,
                LastModifiedAt = author.LastModifiedAt,
                LastModifiedByUserId = author.LastModifiedByUserId
            };
        }
        public static DB.Category ToCategoryDB(this BLL.Category category)
        {
            if (category is null) throw new ArgumentNullException(nameof(category));

            return new DB.Category()
            {
                Name = category.Name,
                Description = category.Description,
                CreatedAt = category.CreatedAt,
                CreatedByUserId = category.CreatedByUserId,
                LastModifiedAt = category.LastModifiedAt,
                LastModifiedByUserId = category.LastModifiedByUserId
            };
        }
        #endregion
    }
}
