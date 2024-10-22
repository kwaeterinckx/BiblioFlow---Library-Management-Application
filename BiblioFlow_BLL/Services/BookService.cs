using DB = BiblioFlow_DB.Entities;

using BiblioFlow_BLL.Entities;
using BiblioFlow_BLL.Mappers;
using BiblioFlow_BLL.Repositories;
using BiblioFlow_DB.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_BLL.Services
{
    public class BookService : IBookRepository<Book>
    {
        private readonly BiblioFlowContext _context;

        public BookService(BiblioFlowContext context)
        {
            _context = context;
        }

        public async Task AddBookAsync(Book book)
        {
            try
            {
                DB.Book newBook = book.ToBookDB();

                ICollection<DB.Author> newAuthors = newBook.Authors;
                ICollection<DB.Category> newCategories = newBook.Categories;

                DB.Book? existingBook;
                if (!string.IsNullOrWhiteSpace(newBook.ISBN))
                {
                    existingBook = await _context.Books.SingleOrDefaultAsync(eb => eb.ISBN == newBook.ISBN);
                }
                else
                {
                    existingBook = await _context.Books.SingleOrDefaultAsync(eb => eb.Title == newBook.Title && eb.Authors.OrderBy(a => a).SequenceEqual(newBook.Authors.OrderBy(a => a)));
                }

                if (existingBook is not null) throw new Exception($"This book already exists: \"{newBook.Title}\"");

                foreach (DB.Author newAuthor in newAuthors)
                {
                    DB.Author? existingAuthor = await _context.Authors.SingleOrDefaultAsync(ea => ea.FirstName.Contains(newAuthor.FirstName) && ea.LastName.Contains(newAuthor.LastName));

                    if (existingAuthor is not null)
                    {
                        newBook.Authors.Remove(newAuthor);
                        newBook.Authors.Add(existingAuthor);
                    }
                }

                foreach (DB.Category newCategory in newCategories)
                {
                    DB.Category? existingCategory = await _context.Categories.SingleOrDefaultAsync(ec => ec.Name == newCategory.Name);

                    if (existingCategory is not null)
                    {
                        newBook.Categories.Remove(newCategory);
                        newBook.Categories.Add(existingCategory);
                    }
                }
                await _context.AddAsync(newBook);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            try
            {
                return await _context.Books.Include(b => b.Authors).Include(b => b.Categories).Select(b => b.ToBookBLL()).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<IEnumerable<Book>> GetBookByAuthorAsync(string bookAuthor)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetBookByCategoryAsync(string bookCategory)
        {
            throw new NotImplementedException();
        }

        public Task<Book?> GetBookByIdAsync(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task<Book?> GetBookByISBNAsync(string isbn)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetBookByPublisherAsync(string bookPublisher)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetBookByTitleAsync(string bookTitle)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBookAsync(int bookId, Book book)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBookAuthorAsync(int bookId, Book book)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBookCategoryAsync(int bookId, Book book)
        {
            throw new NotImplementedException();
        }
    }
}
