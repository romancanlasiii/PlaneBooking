using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaneBooking.Models.Entities.Base
{
    public abstract class EntityBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateCreated { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateModified { get; set; }

        [DataType(DataType.Text), MaxLength(50)]
        public string CreatedBy { get; set; }

        [DataType(DataType.Text), MaxLength(50)]
        public string ModifiedBy { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
