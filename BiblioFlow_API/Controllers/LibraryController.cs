using BiblioFlow_API.Mappers;
using BiblioFlow_API.Models.Library;
using BiblioFlow_API.Services;
using BiblioFlow_BLL.Entities;
using BiblioFlow_BLL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BiblioFlow_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryRepository<Library> _libraryRepository;
        private readonly ICurrentUserRepository _currentUser;

        public LibraryController(ILibraryRepository<Library> libraryRepository, ICurrentUserRepository currentUser)
        {
            _libraryRepository = libraryRepository;
            _currentUser = currentUser;
        }

        [Authorize("AdminRequired")]
        [HttpPost]
        public async Task<IActionResult> AddLibraryAsync(LibraryForm library)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                await _libraryRepository.AddLibraryAsync(library.ToNewLibraryBLL(_currentUser.UserId));

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLibrariesAsync()
        {
            try
            {
                IEnumerable<Library> libraries = await _libraryRepository.GetAllLibrariesAsync();

                return Ok(libraries.Select(l => l.ToLibraryModel()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("details/id")]
        public async Task<IActionResult> GetLibraryByIdAsync(int libraryId)
        {
            try
            {
                Library? library = await _libraryRepository.GetLibraryByIdAsync(libraryId);

                if (library is null) return NotFound();

                return Ok(library.ToLibraryModel());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("details/name")]
        public async Task<IActionResult> GetLibraryByNameAsync(string libraryName)
        {
            try
            {
                Library? library = await _libraryRepository.GetLibraryByNameAsync(libraryName);

                if (library is null) return NotFound();

                return Ok(library.ToLibraryModel());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
