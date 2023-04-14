using System.Collections.Generic;

namespace Assignment_2.Models.DB
{
    public class DBMovie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Plot { get; set; }

        public DBProducer Producer { get; set; }
        public List<DBActor> Actors { get; set; }
        public int YearOfRelease { get; set; }
        public string CoverImage { get; set; }
        public List<DBGenre> Genres { get; set; }
    }
}
