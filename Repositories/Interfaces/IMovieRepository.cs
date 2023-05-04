using Assignment_2.Models.DB;
using Assignment_2.Models.Request;
using System.Collections.Generic;

namespace Assignment_2.Repositories
{
    public interface IMovieRepository
    {
        void Add(MovieRequest movie,int id);
        void Delete(int id);
        MovieDB Get(int id);
        List<MovieDB> GetAll();
        List<List<int>> GetAllMoviesActors();
        List<List<int>> GetAllMoviesGenres();
        List<int> GetMovieActors(int id);
        List<int> GetMovieGenres(int id);
    }
}