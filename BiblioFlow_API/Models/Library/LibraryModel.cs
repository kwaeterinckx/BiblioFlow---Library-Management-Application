namespace BiblioFlow_API.Models.Library
{
    public class LibraryModel
    {
        public int LibraryId { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public required ICollection<OpeningHoursModel> OpeningHours { get; set; }
    }
}
