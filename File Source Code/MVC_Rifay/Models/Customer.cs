using System.ComponentModel.DataAnnotations;

namespace MVC_Rifay.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name must not be empty")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "DOB must not be empty")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Address must not be empty")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Email must not be empty")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password must not be empty")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Phone Number must not be empty")]
        public string? PhoneNumber { get; set; }
        public string? CustImage { get; set; }

        public ICollection<Booking> bookings { get; set; }
    }
}
