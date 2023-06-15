using System.ComponentModel.DataAnnotations;

namespace FML.Models
{
    public class Movie
    {
        [Key]
        public int id { get; set; }
        public string MovieName { get; set; }
        public string MovieYear { get; set; }
        public string MovieDirector { get; set; }
        public string MovieDescription { get; set; }
    }
}
