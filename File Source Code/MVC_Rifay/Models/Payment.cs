using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Rifay.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Booking")]
        public int BookingId { get; set; }

		[ForeignKey("Credit_Card")]
		public int CardNumber { get; set; }
        public Booking? Booking { get; set; }
        public Credit_Card? credit_card { get; set; }
    }
}
