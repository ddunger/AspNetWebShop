using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AspNetWebShop.Models.ProductData
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public required string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
