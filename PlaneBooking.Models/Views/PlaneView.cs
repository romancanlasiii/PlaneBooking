using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PlaneBooking.Models.Views.Base;

namespace PlaneBooking.Models.Views
{
    public class PlaneView : ViewBase
    {
        [Required]
        [DataType(DataType.Text), MaxLength(50), Display(Name = "Body No")]
        public string BodyNo { get; set; }

        [Required]
        [DataType(DataType.Text), MaxLength(50), Display(Name = "Model No")]
        public string Model { get; set; }

        [Display(Name = "Airport")]
        public int AirportId { get; set; }

        [ForeignKey(nameof(AirportId))]
        public AirportView Airport { get; set; }
    }
}
