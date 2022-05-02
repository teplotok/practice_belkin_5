using Microsoft.EntityFrameworkCore;

namespace DBShop.Models
{
    public class CustomerContext : DbContext
    {
        public DbSet<CustomerModel> Customers { get; set; } 
        public DbSet<OrderModel> Orders { get; set; }

        public CustomerContext()
        {
            Database.EnsureCreated();
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=shopdb;Trusted_Connection=True;");
        }
        
    }
}
