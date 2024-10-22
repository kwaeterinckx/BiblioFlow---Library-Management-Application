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
    }
}
