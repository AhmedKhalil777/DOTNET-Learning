namespace Learning.OData.Models
{
    public class Resource
    {
        public int Id { get; set; }

        public string Path { get; set; } = default!;
        public ResourceType Type { get; set; }
    }


    public enum ResourceType
    {
        Image,
    }
}
