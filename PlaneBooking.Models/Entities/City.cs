using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PlaneBooking.Models.Entities.Base;

namespace PlaneBooking.Models.Entities
{
    [Table("Cities", Schema = "PlaneBooking")]
    public class City : EntityBase
    {
        [Required]
        [DataType(DataType.Text), MaxLength(50)]
        public string Name { get; set; }

        [InverseProperty(nameof(Airport.City))]
        public List<Airport> Airports { get; set; } = new List<Airport>();
    }
}
