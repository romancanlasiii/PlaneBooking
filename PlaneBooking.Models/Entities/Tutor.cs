using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PlaneBooking.Models.Entities.Base;

namespace PlaneBooking.Models.Entities
{
    [Table("Tutors", Schema = "PlaneBooking")]
    public class Tutor : EntityBase
    {
        [Required]
        [DataType(DataType.Text), MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Text), MaxLength(50)]
        public string LicenseNo { get; set; }

        [Display(Name = "Airport")]
        public int AirportId { get; set; }

        [ForeignKey(nameof(AirportId))]
        public Airport Airport { get; set; }
    }
}
