using Assignment_2.Models.Request;
using Assignment_2.Models.Response;
using System.Collections.Generic;

namespace Assignment_2.Services
{
    public interface IMovieService
    {
        int Create(RequestMovie movie);
        void Delete(int id);
        ResponseMovie Get(int id);
        List<ResponseMovie> GetAll();
        void Update(int id, RequestMovie movie);
    }
}