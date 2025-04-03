using Inventory_Managment_System.Models.Classes;
using Microsoft.EntityFrameworkCore;
namespace Inventory_Managment_System.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext (DbContextOptions<InventoryDbContext> options) : base(options) 
        { 

        }    
        public DbSet<Order> orders { get; set; }
        public object Orders { get; internal set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<PurchaseDetails> PurchaseDetails { get; set; }
        public DbSet<Purchase> purchases { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }
        public DbSet<Customer> customers { get; set; }


    }
}
