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
                return await _context.Libraries.Include(l => l.OpeningHours.OrderBy(oh => oh.DayOfWeek)).Select(l => l.ToLibraryBLL()).ToListAsync();
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
                DB.Library? library = await _context.Libraries.Include(l => l.OpeningHours.OrderBy(oh => oh.DayOfWeek)).SingleOrDefaultAsync(l => l.LibraryId == libraryId);

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
                DB.Library? library = await _context.Libraries.Include(l => l.OpeningHours.OrderBy(oh => oh.DayOfWeek)).SingleOrDefaultAsync(l => l.Name.Contains(libraryName));

                return library?.ToLibraryBLL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateLibraryAsync(int libraryId, BLL.Library library)
        {
            try
            {
                DB.Library? libraryToUpdate = await _context.Libraries.SingleOrDefaultAsync(l => l.LibraryId == libraryId);

                if (libraryToUpdate is null) throw new ArgumentNullException(nameof(libraryToUpdate));

                libraryToUpdate.Name = library.Name;
                libraryToUpdate.Address = library.Address;
                libraryToUpdate.Phone = library.Phone;
                libraryToUpdate.Email = library.Email;
                libraryToUpdate.LastModifiedAt = library.LastModifiedAt;
                libraryToUpdate.LastModifiedByUserId = library.LastModifiedByUserId;

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateLibraryOpeningHoursAsync(int libraryId, BLL.Library library)
        {
            try
            {
                DB.Library? libraryToUpdate = await _context.Libraries.Include(l => l.OpeningHours).SingleOrDefaultAsync(l => l.LibraryId == libraryId);

                if (libraryToUpdate is null) throw new ArgumentNullException(nameof(libraryToUpdate));

                if (libraryToUpdate.OpeningHours is null) libraryToUpdate.OpeningHours = new List<DB.OpeningHours>();

                ICollection<DB.OpeningHours> currentOpeningHours = libraryToUpdate.OpeningHours;
                ICollection<DB.OpeningHours> newOpeningHours = library.OpeningHours.Select(oh => oh.ToOpeningHoursDB()).ToList();

                foreach (DB.OpeningHours newHours in newOpeningHours)
                {
                    DB.OpeningHours? currentHours = currentOpeningHours.SingleOrDefault(coh => coh.DayOfWeek == newHours.DayOfWeek);

                    if (currentHours is null)
                        libraryToUpdate.OpeningHours.Add(newHours);
                    else
                        currentHours = newHours;
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
