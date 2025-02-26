using Microsoft.AspNetCore.Identity;
using AspNetWebShop.Models.OrderData;
using System.ComponentModel.DataAnnotations;

namespace AspNetWebShop.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        public required virtual Order[] Orders { get; set; }
    }
}
