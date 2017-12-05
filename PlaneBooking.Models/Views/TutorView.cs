using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PlaneBooking.Models.Views.Base;

namespace PlaneBooking.Models.Views
{
    public class TutorView : ViewBase
    {
        [Required]
        [DataType(DataType.Text), MaxLength(100), Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Text), MaxLength(50), Display(Name = "License No")]
        public string LicenseNo { get; set; }

        [Display(Name = "Airport")]
        public int AirportId { get; set; }

        [ForeignKey(nameof(AirportId))]
        public AirportView Airport { get; set; }
    }
}
