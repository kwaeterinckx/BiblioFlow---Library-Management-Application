using BiblioFlow_BLL.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_BLL.Repositories
{
    public interface IBookRepository<TBook> where TBook : IBook
    {
        Task AddBookAsync(TBook book);

        Task<IEnumerable<TBook>> GetAllBooksAsync();
        Task<TBook?> GetBookByIdAsync(int bookId);
        Task<TBook?> GetBookByISBNAsync(string isbn);
        Task<IEnumerable<TBook>> GetBookByTitleAsync(string bookTitle);
        Task<IEnumerable<TBook>> GetBookByAuthorAsync(string bookAuthor);
        Task<IEnumerable<TBook>> GetBookByCategoryAsync(string bookCategory);
        Task<IEnumerable<TBook>> GetBookByPublisherAsync(string bookPublisher);

        Task UpdateBookAsync(int bookId, TBook book);
        Task UpdateBookAuthorAsync(int bookId, TBook book);
        Task UpdateBookCategoryAsync(int bookId, TBook book);
    }
}
