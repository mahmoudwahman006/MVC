using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Rifay.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public int Bed_Count { get; set; }
        public string? active { get; set; }
        public string? cancellation { get; set; }
        [Display(Name ="Image")]
        [DefaultValue("Capture.PNG")]
        public string? imge { get; set; }
		[Required]
		public string? Category { get; set; }
		public string? Food { get; set; }
		[Required]
		public decimal? RCPrice { get; set; }
		[Required]
		public int? RCFloor { get; set; }


		public Booking_Details? booking_details { get; set; }
    }
}
