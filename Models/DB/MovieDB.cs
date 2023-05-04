using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Assignment_2.Models.DB
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
