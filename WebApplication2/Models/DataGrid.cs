using Microsoft.EntityFrameworkCore;
namespace DBShop.Models
{
    public class DataGrid
    {
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<OrderModel> Orders { get; set; }

        public DataGrid(DbSet<OrderModel> orders, DbSet<CustomerModel> customer)
        {
            Orders = orders;
            Customers = customer;
        }
    }
}