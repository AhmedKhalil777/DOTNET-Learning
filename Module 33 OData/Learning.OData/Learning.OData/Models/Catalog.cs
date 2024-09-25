namespace Learning.OData.Models
{
    public class Catalog
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;
        public string Price { get; set; } = default!;
        public string Description { get; set; } = default!;

        public int StockCount { get; set; }

        public ICollection<Resource> Images { get; set; } = default!;
    }
}
