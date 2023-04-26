using Assignment_3.Models.Request;
using Assignment_3.Models.Response;
using System.Collections.Generic;

namespace Assignment_3.Services
{
    public interface IMovieService
    {
        int Create(MovieRequest movie);
        void Delete(int id);
        void UpdateCoverImage(int id, string coverImage);
        MovieResponse Get(int id);
        List<MovieResponse> GetAll();
        void Update(int id, MovieRequest movie);
    }
}