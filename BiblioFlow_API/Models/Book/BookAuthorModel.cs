namespace BiblioFlow_API.Models.Book
{
    public class BookAuthorModel
    {
        public int AuthorId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
