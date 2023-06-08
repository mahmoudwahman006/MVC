using System.ComponentModel.DataAnnotations;

namespace MVC_Rifay.Models
{
	public class Admin
	{
		[Key]
		public int id { get; set; }
		[Required]
		public string? name { get; set; }
		[Required]
		public string? Email { get; set; }
		[Required]
		public string? Password { get; set; }
	}
}
