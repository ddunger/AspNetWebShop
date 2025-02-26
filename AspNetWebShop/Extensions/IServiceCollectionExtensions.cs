using AspNetWebShop.Data;
using AspNetWebShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AspNetWebShop.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services,
     IConfiguration configuration)
        {
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(100);
                options.Cookie.Name = ".AspNetWebShop.Session";
                options.Cookie.IsEssential = true;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
            })
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            // Add services to the container.
            services.AddControllersWithViews();



            return services;
        }
    }
}
