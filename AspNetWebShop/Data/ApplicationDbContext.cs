using AspNetWebShop.Models;
using AspNetWebShop.Models.ProductData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetWebShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufactorers { get; set; }
        public DbSet<CloathingSize> CloathingSizes { get; set; }
        public DbSet<FootwearSize> FootwearSizes { get; set; }


        // dodati kasnije:
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<Category>()
               .HasIndex(_ => _.Name)
               .IsUnique();

            builder.Entity<Product>()
                .HasIndex(_ => _.Name)
                .IsUnique();

            builder.Entity<Product>()
               .HasOne(p => p.Manufacturer)
               .WithMany()
               .HasForeignKey(p => p.ManufacturerId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Product>()
               .HasOne(p => p.Category)
              .WithMany(c => c.Products)
              .HasForeignKey(p => p.CategoryId);

            builder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(8, 4)");

            builder.Entity<Manufacturer>().HasData(
                new Manufacturer { Id = 1, Name = "Nike" },
                new Manufacturer { Id = 2, Name = "Adidas" },
                new Manufacturer { Id = 3, Name = "Under Armour" },
                new Manufacturer { Id = 4, Name = "Puma" },
                new Manufacturer { Id = 5, Name = "Reebok" }
            );

            builder.Entity<CloathingSize>().HasData(
                new CloathingSize { Id = 1, Name = "XS" },
                new CloathingSize { Id = 2, Name = "S" },
                new CloathingSize { Id = 3, Name = "M" },
                new CloathingSize { Id = 4, Name = "L" },
                new CloathingSize { Id = 5, Name = "XL" },
                new CloathingSize { Id = 6, Name = "XXL" }
             );

            builder.Entity<FootwearSize>().HasData(
                new FootwearSize { Id = 1, Name = "38" },
                new FootwearSize { Id = 2, Name = "40" },
                new FootwearSize { Id = 3, Name = "42" },
                new FootwearSize { Id = 4, Name = "44" },
                new FootwearSize { Id = 5, Name = "45 1/2" }
            );

            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Cloathing" },
                new Category { Id = 2, Name = "Footwear" }
            );

            builder.Entity<Color>().HasData(
                new Color { Id = 1, Name = "Red" },
                new Color { Id = 2, Name = "Blue" },
                new Color { Id = 3, Name = "Black" },
                new Color { Id = 4, Name = "Yellow" },
                new Color { Id = 5, Name = "Green" },
                new Color { Id = 6, Name = "Gray" }

             );

        }
    }
}
