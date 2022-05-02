using Microsoft.EntityFrameworkCore;

namespace DBShop.Models
{
    public class OrderView
    {
        public int CustomerId { get; set; }

        public DbSet<OrderModel> set { get; set; }

        public OrderView(int id,DbSet<OrderModel> set)
        {
            CustomerId= id;
            this.set=set;
        }

    }
}