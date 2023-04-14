using Assignment_2.Models.DB;
using System.Collections.Generic;

namespace Assignment_2.Models.Request
{
    public class RequestMovie
    {
        public string Name { get; set; }

        public string Plot { get; set; }

        public RequestProducer Producer { get; set; }
        public List<RequestActor> Actors { get; set; }
        public int YearOfRelease { get; set; }
        public string CoverImage { get; set; }
        public List<RequestGenre> Genres { get; set; }

    }
}
