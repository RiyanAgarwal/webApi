using Assignment_2.Models.Request;
using Assignment_2.Models.Response;
using System.Collections.Generic;

namespace Assignment_2.Services
{
    public interface IMovieService
    {
        int Create(MovieRequest movie);
        void Delete(int id);

        MovieResponse Get(int id);
        List<MovieResponse> GetAll();
        void Update(int id, MovieRequest movie);
    }
}