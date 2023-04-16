using System.Collections.Generic;

namespace Assignment_2.Models.Request
{
    public class MovieRequest
    {
        public string Name { get; set; }

        public string Plot { get; set; }

        public ProducerRequest Producer { get; set; }
        public List<ActorRequest> Actors { get; set; }
        public int YearOfRelease { get; set; }
        public string CoverImage { get; set; }
        public List<GenreRequest> Genres { get; set; }
    }
}