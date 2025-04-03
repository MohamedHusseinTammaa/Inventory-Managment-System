using Inventory_Managment_System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Inventory_Managment_System.Interfaces;
using Inventory_Managment_System.Services;
using Inventory_Managment_System.Models.Services;
using Inventory_Managment_System.Repositories;
using Inventory_Managment_System.UnitOfWork;
using Inventory_Managment_System.Models.Classes;

namespace Inventory_Managment_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Register DbContext and Services here before building the app
            builder.Services.AddDbContext<InventoryDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"),
                    b => b.MigrationsAssembly(typeof(InventoryDbContext).FullName)));

            // Register repositories and unit of work
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<IUnitOfWork, unitOfWork>();
            builder.Services.AddScoped<ICustomer, CustomerServices>();
            builder.Services.AddScoped<IProduct, productServices>();
            builder.Services.AddScoped<ICategory, CategoryServices>();
            builder.Services.AddScoped<IBrand, BrandServices>();
            builder.Services.AddScoped<ISupplier, SupplierServices>();
            builder.Services.AddScoped<IOrder, OrderService>();
            builder.Services.AddScoped<IOrderDetails, OrderDetailsService>();


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
