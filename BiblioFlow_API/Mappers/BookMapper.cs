using API = BiblioFlow_API.Models.Book;
using BLL = BiblioFlow_BLL.Entities;

namespace BiblioFlow_API.Mappers
{
    internal static class BookMapper
    {
        #region To Model
        public static API.BookModel ToBookModel(this BLL.Book book)
        {
            if (book is null) throw new ArgumentNullException(nameof(book));

            return new API.BookModel()
            {
                BookId = book.BookId,
                ISBN = book.ISBN,
                Title = book.Title,
                Description = book.Description,
                Publisher = book.Publisher,
                PublicationYear = book.PublicationYear,
                Price = book.Price,
                Authors = book.Authors.Select(a => a.ToAuthorModel()).ToList(),
                Categories = book.Categories.Select(c => c.ToCategoryModel()).ToList()
            };
        }
        public static API.BookAuthorModel ToAuthorModel(this BLL.Author author)
        {
            if (author is null) throw new ArgumentNullException(nameof(author));

            return new API.BookAuthorModel()
            {
                AuthorId = author.AuthorId,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Bio = author.Bio
            };
        }
        public static API.BookCategoryModel ToCategoryModel(this BLL.Category category)
        {
            if (category is null) throw new ArgumentNullException(nameof(category));

            return new API.BookCategoryModel()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description
            };
        }
        #endregion

        #region To BLL
        public static BLL.Book ToNewBookBLL(this API.BookForm book, Guid createdByUserId)
        {
            if (book is null) throw new ArgumentNullException(nameof(book));

            return new BLL.Book(book.ISBN, book.Title, book.Description, book.Publisher, book.PublicationYear, book.Price, DateTime.Now, null, createdByUserId, null, book.Authors.Select(a => a.ToNewAuthorBLL(createdByUserId)).ToList(), book.Categories.Select(c => c.ToNewCategoryBLL(createdByUserId)).ToList());
        }
        public static BLL.Author ToNewAuthorBLL(this API.BookAuthorForm author, Guid createdByUserId)
        {
            if (author is null) throw new ArgumentNullException(nameof(author));

            return new BLL.Author(author.FirstName, author.LastName, null, DateTime.Now, null, createdByUserId, null);
        }
        public static BLL.Category ToNewCategoryBLL(this API.BookCategoryForm category, Guid createdByUserId)
        {
            if (category is null) throw new ArgumentNullException(nameof(category));

            return new BLL.Category(category.Name, null, DateTime.Now, null, createdByUserId, null);
        }
        #endregion
    }
}
