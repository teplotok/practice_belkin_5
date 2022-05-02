namespace DBShop.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public string Product { get; set; }

        public int Cost { get; set; }

        public int CustomerId   { get; set; }

        public CustomerModel CustomerModel { get; set; }
        
       
    }
}
