using Inventory_Managment_System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Inventory_Managment_System.Interfaces;
using Inventory_Managment_System.Services;
using Inventory_Managment_System.Models.Services;
using productServices = Inventory_Managment_System.Models.Services.productServices;

namespace Inventory_Managment_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("defaultConnection");

            // Register DbContext and Services here before building the app
            builder.Services.AddDbContext<InventoryDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IProduct, productServices>();  // Register your service
            builder.Services.AddScoped<ICategory, CategoryServices>();
            builder.Services.AddScoped<IBrand, BrandServices>();
            builder.Services.AddScoped<ISupplier, SupplierServices>();
            builder.Services.AddScoped<Iorder, orderService>();
           
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
