using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Rifay.Models
{
    public class Credit_Card
    {
        [Key]
        public string? CardNumber { get; set; }
        [Required]
        public string? CardHolderName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string? CVV { get; set; }
        public Customer? Customer { get; set; }
        public virtual ICollection<Payment> payments { get; set; }  
    }
}
