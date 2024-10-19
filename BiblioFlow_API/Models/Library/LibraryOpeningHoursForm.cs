using System.ComponentModel.DataAnnotations;

namespace BiblioFlow_API.Models.Library
{
    public class LibraryOpeningHoursForm
    {
        [Required]
        public required ICollection<OpeningHoursForm> OpeningHours { get; set; }
    }
}
