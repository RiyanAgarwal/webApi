using Assignment_4.Models.DB;
using Assignment_4.Models.Request;
using System.Collections.Generic;

namespace Assignment_4.Repositories
{
    public interface IMovieRepository
    {
        void Add(MovieRequest movie);
        void Delete(int id);
        MovieDB Get(int id);
        List<int> GetActors(int id);
        List<MovieDB> GetAll();
        List<int> GetGenres(int id);
        void Update(MovieRequest movie, int id);
        void UpdateCoverImage(int Id, string CoverImage);
    }
}