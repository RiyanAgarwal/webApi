using Assignment_2.Models.DB;
using System.Collections.Generic;

namespace Assignment_2.Repositories
{
    public interface IActorRepository
    {
        void Add(DBActor actor);
        void Delete(int id);
        DBActor Get(int id);
        List<DBActor> GetAll();
    }
}