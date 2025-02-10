namespace Learning.OData.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public ICollection<Order> Orders { get; set; } = default!;
    }
}
