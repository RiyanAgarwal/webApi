using Assignment_2.Models.DB;
using System.Collections.Generic;

namespace Assignment_2.Repositories
{
    public interface IGenreRepository
    {
        void Add(GenreDB genre);
        void Delete(int id);
        GenreDB Get(int id);
        List<GenreDB> GetAll();
    }
}