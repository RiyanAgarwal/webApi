using Assignment_3.Models.DB;
using System.Collections.Generic;

namespace Assignment_3.Repositories
{
    public interface IActorRepository
    {
        void Add(ActorDB actor);
        void Delete(int id);
        ActorDB Get(int id);
        List<ActorDB> GetAll();
    }
}