using System.ComponentModel.DataAnnotations;

namespace BiblioFlow_API.Models.Book
{
    public class BookForm
    {
        [MaxLength(20)]
        public string? ISBN { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Publisher { get; set; }

        [Required]
        public int PublicationYear { get; set; }

        public decimal? Price { get; set; }

        public required ICollection<BookAuthorForm> Authors { get; set; }

        public required ICollection<BookCategoryForm> Categories { get; set; }
    }
}
