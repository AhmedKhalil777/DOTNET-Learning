namespace MyWebApp.Models {
    public class Transformer {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Color { get; set; }

        public Transformer(int id, string name, string location, string color) {
            this.ID = id;
            this.Name = name;
            this.Location = location;
            this.Color = color;
        }
    }
}