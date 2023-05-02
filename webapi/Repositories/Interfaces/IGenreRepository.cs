using Assignment_4.Models.DB;
using System.Collections.Generic;

namespace Assignment_4.Repositories
{
    public interface IGenreRepository
    {
        void Add(GenreDB genre);
        void Delete(int id);
        GenreDB Get(int id);
        List<GenreDB> GetAll();
        void Update(GenreDB genre);
    }
}