using Assignment_4.Models.Request;
using Assignment_4.Models.Response;
using System.Collections.Generic;

namespace Assignment_4.Services
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