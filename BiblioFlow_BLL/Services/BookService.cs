﻿using DB = BiblioFlow_DB.Entities;

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

                List<DB.Author> authorsToAdd = new List<DB.Author>();
                List<DB.Category> categoriesToAdd = new List<DB.Category>();

                DB.Book? existingBook;

                if (!string.IsNullOrWhiteSpace(newBook.ISBN))
                {
                    existingBook = await _context.Books.SingleOrDefaultAsync(eb => eb.ISBN == newBook.ISBN);
                }
                else
                {
                    List<DB.Book> potentialBooks = await _context.Books.Include(b => b.Authors).Where(b => b.Title == newBook.Title).ToListAsync();

                    var normalizedNewAuthors = newBook.Authors
                        .Select(a => (FirstName: a.FirstName.Trim().ToLower(), LastName: a.LastName.Trim().ToLower()))
                        .OrderBy(a => a.LastName).ThenBy(a => a.FirstName).ToList();

                    existingBook = potentialBooks.SingleOrDefault(pb => pb.Authors
                        .Select(a => (FirstName: a.FirstName.Trim().ToLower(), LastName: a.LastName.Trim().ToLower()))
                        .OrderBy(a => a.LastName).ThenBy(a => a.FirstName)
                        .SequenceEqual(normalizedNewAuthors));
                }

                if (existingBook is not null) throw new Exception($"This book already exists: \"{newBook.Title}\"");

                foreach (DB.Author newAuthor in newAuthors)
                {
                    DB.Author? existingAuthor = await _context.Authors
                        .SingleOrDefaultAsync(ea => ea.FirstName.Trim().ToLower() == newAuthor.FirstName.Trim().ToLower() &&
                            ea.LastName.Trim().ToLower() == newAuthor.LastName.Trim().ToLower());

                    if (existingAuthor is not null)
                    {
                        authorsToAdd.Add(existingAuthor);
                    }
                    else
                    {
                        authorsToAdd.Add(newAuthor);
                    }
                }
                newBook.Authors = authorsToAdd;

                foreach (DB.Category newCategory in newCategories)
                {
                    DB.Category? existingCategory = await _context.Categories
                        .SingleOrDefaultAsync(ec => ec.Name.Trim().ToLower() == newCategory.Name.Trim().ToLower());

                    if (existingCategory is not null)
                    {
                        categoriesToAdd.Add(existingCategory);
                    }
                    else
                    {
                        categoriesToAdd.Add(newCategory);
                    }
                }
                newBook.Categories = categoriesToAdd;

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

        public Task<Book?> GetBookByIdAsync(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task<Book?> GetBookByISBNAsync(string isbn)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetBookByTitleAsync(string bookTitle)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetBookByAuthorAsync(string bookAuthor)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetBookByCategoryAsync(string bookCategory)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetBookByPublisherAsync(string bookPublisher)
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
