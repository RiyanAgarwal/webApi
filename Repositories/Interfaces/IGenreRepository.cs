using Assignment_2.Models.DB;
using Assignment_2.Models.Request;
using System.Collections.Generic;

namespace Assignment_2.Repositories
{
    public interface IGenreRepository
    {
        void Add(GenreRequest genre, int id);
        void Delete(int id);
        GenreDB Get(int id);
        List<GenreDB> GetAll();
    }
}