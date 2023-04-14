using Assignment_2.Models.Response;
using System.Collections.Generic;

namespace Assignment_2.Models.Response
{
    public class ResponseMovie
    {
        public string Name { get; set; }

        public string Plot { get; set; }

        public ResponseProducer Producer { get; set; }
        public List<ResponseActor> Actors { get; set; }
        public int YearOfRelease { get; set; }
        public string CoverImage { get; set; }
        public List<ResponseGenre> Genres { get; set; }
    }
}
