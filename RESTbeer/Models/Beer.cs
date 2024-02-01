namespace RESTbeer.Models
{
    public class Beer
    {
        public int Id { get; set; }
        public string? User { get; set; }
        public string? Name { get; set; }
        public string? Style { get; set; }
        public double Abv { get; set; }
        public double Volume { get; set; }
        public string? PictureUrl { get; set; }
        public int HowMany { get; set; }
    }
}
