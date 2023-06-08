using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Rifay.Models
{
    public class Booking_Details
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Booking")]
        public int BookingId { get; set; }
        public Booking ?Booking { get; set; }

        [ForeignKey("Rooms")]
        public int RoomId { get; set; }
        public Room?Room { get; set; }
        public int TotalDays { get; set; }
        public decimal BookingAmount { get; set; }
        [NotMapped]
        public virtual ICollection<Room> ? rooms { get; set; }
        

    }
}
