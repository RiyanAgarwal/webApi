using Assignment_2.Models.DB;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        readonly List<GenreDB> _genres;
        public GenreRepository() => _genres = new();
        public List<GenreDB> GetAll() => _genres.ToList();
        public GenreDB Get(int id) => _genres.ToList().Where(x => x.Id == id).FirstOrDefault();
        public void Add(GenreDB genre) => _genres.Add(genre);
        public void Delete(int id) => _genres.Remove(_genres.ToList().Where(x => x.Id == id).First());
    }
}