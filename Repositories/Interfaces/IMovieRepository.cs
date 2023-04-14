using Assignment_2.Models.DB;
using System.Collections.Generic;

namespace Assignment_2.Repositories
{
    public interface IMovieRepository
    {
        void Add(DBMovie movie);
        void Delete(int id);
        DBMovie Get(int id);
        List<DBMovie> GetAll();
    }
}