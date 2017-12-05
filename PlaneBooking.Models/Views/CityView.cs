using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PlaneBooking.Models.Views.Base;

namespace PlaneBooking.Models.Views
{
    public class CityView : ViewBase
    {
        [Required]
        [DataType(DataType.Text), MaxLength(50), Display(Name = "City")]
        public string Name { get; set; }

        [InverseProperty(nameof(AirportView.City))]
        public List<AirportView> Airports { get; set; } = new List<AirportView>();
    }
}
