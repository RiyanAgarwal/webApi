using Assignment_2.Models.DB;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        readonly List<MovieDB> _movies;
        public MovieRepository() => _movies = new();
        public List<MovieDB> GetAll() => _movies.ToList();
        public MovieDB Get(int id) => _movies.ToList().Where(x => x.Id == id).FirstOrDefault();
        public void Add(MovieDB movie) => _movies.Add(movie);
        public void Delete(int id) => _movies.Remove(_movies.ToList().Where(x => x.Id == id).First());
    }
}