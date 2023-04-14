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

            return _genres.ToList();
        }
        public DBGenre Get(int id)
        {
            return _genres.ToList().Where(x => x.Id == id).First();
        }

        public void Add(DBGenre genre)
        {
            _genres.Add(genre);
        }
        public void Delete(int id)
        {
            _genres.Remove(_genres.ToList().Where(x => x.Id == id).First());
        }
    }

}
