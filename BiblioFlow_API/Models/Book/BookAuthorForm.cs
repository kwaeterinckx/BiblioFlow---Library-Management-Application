using System.ComponentModel.DataAnnotations;

namespace BiblioFlow_API.Models.Book
{
    public class BookAuthorForm
    {
        [Required]
        [MaxLength(100)]
        public required string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public required string LastName { get; set; }
    }
}
