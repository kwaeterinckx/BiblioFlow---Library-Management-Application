using BiblioFlow_BLL.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_BLL.Repositories
{
    public interface ILibraryRepository<TLibrary> where TLibrary : ILibrary
    {
        Task AddLibraryAsync(TLibrary library);

        Task<IEnumerable<TLibrary>> GetAllLibrariesAsync();
        Task<TLibrary?> GetLibraryByIdAsync(int libraryId);
        Task<TLibrary?> GetLibraryByNameAsync(string libraryName);

        Task UpdateLibraryAsync(int libraryId, TLibrary library);
        Task UpdateLibraryOpeningHoursAsync(int libraryId, TLibrary library);
    }
}
