using Assignment_2.Models.DB;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Assignment_2.Repositories

{
    public class GenreRepository : IGenreRepository
    {
        private readonly List<DBGenre> _genres;
        public GenreRepository()
        {
            _genres = new List<DBGenre>();
        }

        public List<DBGenre> GetAll()
        {
            if (_genres == null)
            {
                throw new ArgumentNullException("Genres list is empty");
            }
            return _genres.ToList();
        }
        public DBGenre Get(int id)
        {
            var genreWithId = from genre in _genres
                              where genre.Id == id
                              select genre;
            if (genreWithId.Count() != 1)
            {
                throw new ArgumentOutOfRangeException("Invalid genre id");
            }
            return genreWithId.First();
        }

        public void Add(DBGenre genre)
        {
            _genres.Add(genre);
        }
        public void Delete(int id)
        {
            var genreWithId = from genre in _genres
                              where genre.Id == id
                              select genre;
            if (genreWithId.Count() != 1)
            {
                throw new ArgumentOutOfRangeException("Invalid genre id");
            }
            _genres.Remove(genreWithId.First());
        }
    }

}
