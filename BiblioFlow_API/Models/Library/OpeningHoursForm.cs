using System.ComponentModel.DataAnnotations;

namespace BiblioFlow_API.Models.Library
{
    public class OpeningHoursForm
    {
        [Required]
        public int DayOfWeek { get; set; }

        [RegularExpression(@"^([01][0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Invalid time format. Please use the format hh:mm.")]
        public string? OpenTime { get; set; }

        [RegularExpression(@"^([01][0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Invalid time format. Please use the format hh:mm.")]
        public string? CloseTime { get; set; }

        [Required]
        public bool IsClosed { get; set; }
    }
}
