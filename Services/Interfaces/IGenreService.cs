using Assignment_2.Models.Request;
using Assignment_2.Models.Response;
using System.Collections.Generic;

namespace Assignment_2.Services
{
    public interface IGenreService
    {
        int Create(GenreRequest genre);
        void Delete(int id);
        GenreResponse Get(int id);
        List<GenreResponse> GetAll();
        void Update(int id, GenreRequest genre);
    }
}