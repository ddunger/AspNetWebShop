using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetWebShop.Models.OrderData
{
    public class Order
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Zip { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }


        [Required]
        [Column(TypeName = "decimal(9, 2)")] 
        public decimal Total { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
