using System.Collections.Generic;

namespace Assignment_4.Models.DB
{
    public class MovieDB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Plot { get; set; }
        public int ProducerId { get; set; }
        public int YearOfRelease { get; set; }
        public string CoverImage { get; set; }
    }
}
