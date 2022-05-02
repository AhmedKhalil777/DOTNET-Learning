namespace MyWebApp.Models {
    public class Country {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string NationalFlagPath { get; set; }

        public Country(string code, string name, string continent) {
            this.Code = code;
            this.Name = name;
            this.Continent = continent;
            this.NationalFlagPath = "Images/Default.png";
        }
    }
}