using System.ComponentModel.DataAnnotations;

namespace BiblioFlow_API.Models.Book
{
    public class BookCategoryForm
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }
    }
}
