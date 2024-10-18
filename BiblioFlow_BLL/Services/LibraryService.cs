using DB = BiblioFlow_DB.Entities;
using BLL = BiblioFlow_BLL.Entities;

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
    public class LibraryService : ILibraryRepository<BLL.Library>
    {
        private readonly BiblioFlowContext _context;

        public LibraryService(BiblioFlowContext context)
        {
            _context = context;
        }

        public async Task AddLibraryAsync(BLL.Library library)
        {
            try
            {
                DB.Library newLibrary = library.ToLibraryDB();

                await _context.Libraries.AddAsync(newLibrary);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<BLL.Library>> GetAllLibrariesAsync()
        {
            try
            {
                return await _context.Libraries.Include(l => l.OpeningHours).Select(l => l.ToLibraryBLL()).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BLL.Library?> GetLibraryByIdAsync(int libraryId)
        {
            try
            {
                DB.Library? library = await _context.Libraries.Include(l => l.OpeningHours).SingleOrDefaultAsync(l => l.LibraryId == libraryId);

                return library?.ToLibraryBLL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BLL.Library?> GetLibraryByNameAsync(string libraryName)
        {
            try
            {
                DB.Library? library = await _context.Libraries.Include(l => l.OpeningHours).SingleOrDefaultAsync(l => l.Name.Contains(libraryName));

                return library?.ToLibraryBLL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task UpdateLibraryAsync(int libraryId, BLL.Library library)
        {
            throw new NotImplementedException();
        }

        public Task UpdateLibraryOpeningHoursAsync(int libraryId, BLL.Library library)
        {
            throw new NotImplementedException();
        }
    }
}
