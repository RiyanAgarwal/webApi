using Assignment_2.Models.DB;
using System.Collections.Generic;

namespace Assignment_2.Repositories
{
    public interface IMovieRepository
    {
        void Add(MovieDB movie);
        void Delete(int id);
        MovieDB Get(int id);
        List<MovieDB> GetAll();
    }
}