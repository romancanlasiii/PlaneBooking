using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PlaneBooking.Models.Entities.Base;

namespace PlaneBooking.Models.Entities
{
    [Table("Airports", Schema = "PlaneBooking")]
    public class Airport : EntityBase
    {
        [Required]
        [DataType(DataType.Text), MaxLength(50)]
        public string Name { get; set; }

        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public City City { get; set; }

        [InverseProperty(nameof(Plane.Airport))]
        public List<Plane> Planes { get; set; } = new List<Plane>();

        [InverseProperty(nameof(Tutor.Airport))]
        public List<Tutor> Tutors { get; set; } = new List<Tutor>();

        public bool IsForceClose { get; set; }
    }
}
