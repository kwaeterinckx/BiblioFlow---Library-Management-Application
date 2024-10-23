using BiblioFlow_API.Mappers;
using BiblioFlow_API.Models.Book;
using BiblioFlow_API.Services;
using BiblioFlow_BLL.Entities;
using BiblioFlow_BLL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiblioFlow_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository<Book> _bookRepository;
        private readonly ICurrentUserRepository _currentUser;

        public BookController(IBookRepository<Book> bookRepository, ICurrentUserRepository currentUser)
        {
            _bookRepository = bookRepository;
            _currentUser = currentUser;
        }

        [HttpPost]
        public async Task<IActionResult> AddBookAsync(BookForm book)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                await _bookRepository.AddBookAsync(book.ToNewBookBLL(_currentUser.UserId));

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            try
            {
                IEnumerable<Book> books = await _bookRepository.GetAllBooksAsync();

                return Ok(books.Select(b => b.ToBookModel()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("details/id")]
        public async Task<IActionResult> GetBookByIdAsync(int bookId)
        {
            try
            {
                Book? book = await _bookRepository.GetBookByIdAsync(bookId);

                if (book is null) return NotFound();

                return Ok(book.ToBookModel());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("details/isbn")]
        public async Task<IActionResult> GetBookByISBNAsync(string isbn)
        {
            try
            {
                Book? book = await _bookRepository.GetBookByISBNAsync(isbn);

                if (book is null) return NotFound();

                return Ok(book.ToBookModel());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("details/title")]
        public async Task<IActionResult> GetBookByTitleAsync(string bookTitle)
        {
            try
            {
                IEnumerable<Book> books = await _bookRepository.GetBookByTitleAsync(bookTitle);

                return Ok(books.Select(b => b.ToBookModel()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("details/author")]
        public async Task<IActionResult> GetBookByAuthorAsync(string bookAuthor)
        {
            try
            {
                IEnumerable<Book> books = await _bookRepository.GetBookByAuthorAsync(bookAuthor);

                return Ok(books.Select(b => b.ToBookModel()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("details/category")]
        public async Task<IActionResult> GetBookByCategoryAsync(string bookCategory)
        {
            try
            {
                IEnumerable<Book> books = await _bookRepository.GetBookByCategoryAsync(bookCategory);

                return Ok(books.Select(b => b.ToBookModel()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("details/publisher")]
        public async Task<IActionResult> GetBookByPublisherAsync(string bookPublisher)
        {
            try
            {
                IEnumerable<Book> books = await _bookRepository.GetBookByPublisherAsync(bookPublisher);

                return Ok(books.Select(b => b.ToBookModel()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
