using Assignment_3.Models.DB;
using Assignment_3.Models.Request;
using System.Collections.Generic;

namespace Assignment_3.Repositories
{
    public interface IGenreRepository
    {
        void Add(GenreRequest genre);
        void Delete(int id);
        GenreDB Get(int id);
        List<GenreDB> GetAll();
        void Update(GenreRequest genre, int id);
    }
}