using Assignment_2.Models.DB;
using System.Collections.Generic;

namespace Assignment_2.Repositories
{
    public interface IGenreRepository
    {
        void Add(DBGenre genre);
        void Delete(int id);
        DBGenre Get(int id);
        List<DBGenre> GetAll();
    }
}