using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PlaneBooking.Models.Views.Base;

namespace PlaneBooking.Models.Views
{
    public class AirportView : ViewBase
    {
        [Required]
        [DataType(DataType.Text), MaxLength(50)]
        public string Name { get; set; }

		[Display(Name = "City")]
        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public CityView City { get; set; }

        [InverseProperty(nameof(PlaneView.Airport))]
        public List<PlaneView> Planes { get; set; } = new List<PlaneView>();

        [InverseProperty(nameof(TutorView.Airport))]
        public List<TutorView> Tutors { get; set; } = new List<TutorView>();

		[Display(Name = "Force Close?")]
        public bool IsForceClose { get; set; }
    }
}
