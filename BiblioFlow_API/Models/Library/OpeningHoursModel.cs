namespace BiblioFlow_API.Models.Library
{
    public class OpeningHoursModel
    {
        public int OpeningHourId { get; set; }
        public int DayOfWeek { get; set; }
        public TimeOnly? OpenTime { get; set; }
        public TimeOnly? CloseTime { get; set; }
        public bool IsClosed { get; set; }
    }
}
