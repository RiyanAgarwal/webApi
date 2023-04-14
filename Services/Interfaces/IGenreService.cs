using Assignment_2.Models.Request;
using Assignment_2.Models.Response;
using System.Collections.Generic;

namespace Assignment_2.Services
{
    public interface IGenreService
    {
        int Create(RequestGenre genre);
        void Delete(int id);
        ResponseGenre Get(int id);
        List<ResponseGenre> GetAll();
        void Update(int id, RequestGenre genre);
    }
}