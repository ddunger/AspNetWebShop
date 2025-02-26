using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AspNetWebShop.Models.OrderData
{
    public class OrderItem
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string ProductName { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal ProductPrice { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal TotalPrice { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Manufactorer { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? Color { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string Size { get; set; }


        [Required]
        public int ProductId { get; set; }

        [Required]
        public int OrderId { get; set; }

    }
}
