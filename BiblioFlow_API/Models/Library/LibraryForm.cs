using System.ComponentModel.DataAnnotations;

namespace BiblioFlow_API.Models.Library
{
    public class LibraryForm
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public required string Address { get; set; }

        [Required]
        [MaxLength(20)]
        public required string Phone { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(320)]
        public required string Email { get; set; }
    }
}
