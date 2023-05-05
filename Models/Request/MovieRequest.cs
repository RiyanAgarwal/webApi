using System.Collections.Generic;

namespace Assignment_3.Models.Request
{
    public class MovieRequest
    {
        public string Name { get; set; }
        public string Plot { get; set; }
        public int ProducerId { get; set; }
        public string ActorsIds { get; set; }
        public int YearOfRelease { get; set; }
        public string CoverImage { get; set; }
        public string GenresIds { get; set; }
    }
}