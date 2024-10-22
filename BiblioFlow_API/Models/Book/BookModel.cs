namespace BiblioFlow_API.Models.Book
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string? ISBN { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public decimal? Price { get; set; }
        public required ICollection<BookAuthorModel> Authors { get; set; }
        public required ICollection<BookCategoryModel> Categories { get; set; }
    }
}
