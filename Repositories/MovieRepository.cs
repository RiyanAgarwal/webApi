using Assignment_2.Models.DB;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Assignment_2.Repositories

{
    public class MovieRepository : IMovieRepository
    {
        private readonly List<DBMovie> _movies;
        public MovieRepository()
        {
            _movies = new List<DBMovie>();
        }

        public List<DBMovie> GetAll()
        {
 
            return _movies.ToList();
        }
        public DBMovie Get(int id)
        {
            return _movies.ToList().Where(x=>x.Id == id).First();
        }

        public void Add(DBMovie movie)
        {
            _movies.Add(movie);
        }
        public void Delete(int id)
        {
            _movies.Remove(_movies.ToList().Where(x => x.Id == id).First());
        }
    }

}
