using Assignment_4.Models.Request;
using Assignment_4.Models.Response;
using System.Collections.Generic;

namespace Assignment_4.Services
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