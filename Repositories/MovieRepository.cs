using Assignment_2.Models.DB;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Assignment_2.Repositories

{
    public class MovieRepository
    {
        private readonly List<DBMovie> _movies;
        public MovieRepository()
        {
            _movies = new List<DBMovie>();
        }

        public List<DBMovie> GetAll()
        {
            if (_movies == null)
            {
                throw new ArgumentNullException("Movies list is empty");
            }
            return _movies.ToList();
        }
        public DBMovie Get(int id)
        {
            var movieWithId = from movie in _movies
                                 where movie.Id == id
                                 select movie;
            if (movieWithId.Count() != 1)
            {
                throw new ArgumentOutOfRangeException("Invalid movie id");
            }
            return movieWithId.First();
        }

        public void Add(DBMovie movie)
        {
            _movies.Add(movie);
        }
        public void Delete(int id)
        {
            var movieWithId = from movie in _movies
                                 where movie.Id == id
                                 select movie;
            if (movieWithId.Count() != 1)
            {
                throw new ArgumentOutOfRangeException("Invalid movie id");
            }
            _movies.Remove(movieWithId.First());
        }
    }

}
