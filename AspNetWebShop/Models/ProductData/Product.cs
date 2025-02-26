using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetWebShop.Models.ProductData
{
    public class Product
    {
        [Key]
        public int Id { get; set; } //PK

        [StringLength(150)]
        public required string Name { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(8, 4)")]
        public required decimal Price { get; set; }

        public int CategoryId { get; set; } // Foreign key for Category
        [ValidateNever]
        public virtual Category Category { get; set; } // Navigation property to Category

        public  int ManufacturerId { get; set; } // Explicit FK for Manufacturer
        public  bool HasColors { get; set; } = false; //default false for having color options

        [NotMapped]
        public virtual Color[]? Colors { get; set; }
        [NotMapped]
        public virtual Manufacturer? Manufacturer { get; set; } // many products - one manufactorer

    }
}
