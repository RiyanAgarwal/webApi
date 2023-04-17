using System.Collections.Generic;

namespace Assignment_2.Models.DB
{
    public class MovieDB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Plot { get; set; }
        public ProducerDB Producer { get; set; }
        public List<ActorDB> Actors { get; set; }
        public int YearOfRelease { get; set; }
        public string CoverImage { get; set; }
        public List<GenreDB> Genres { get; set; }
    }
}
