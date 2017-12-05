using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PlaneBooking.Models.Entities.Base;

namespace PlaneBooking.Models.Entities
{
    [Table("Planes", Schema = "PlaneBooking")]
    public class Plane : EntityBase
    {
        [Required]
        [DataType(DataType.Text), MaxLength(50)]
        public string BodyNo { get; set; }

        [Required]
        [DataType(DataType.Text), MaxLength(50)]
        public string Model { get; set; }

        [Display(Name = "Airport")]
        public int AirportId { get; set; }

        [ForeignKey(nameof(AirportId))]
        public Airport Airport { get; set; }
    }
}
