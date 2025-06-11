using MyMvcApp.Controllers;

namespace MyMvcApp.Models
{
    public class Landmark
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int YearEstablished { get; set; }
    }
}
