using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Rifay.Models
{
    public class Booking
    {
        [Key]
        public int booking_id { get; set; }
        [ForeignKey("Customer")]
        public int customer_id { get; set; }
		public DateTime CheckIn { get; set; }
		public DateTime CheckOut { get; set; }
		public virtual Booking_Details? booking_details {get;set; }
        public virtual Payment? payment {get;set; }
    }
}
