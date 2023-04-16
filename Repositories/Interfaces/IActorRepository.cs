using Assignment_2.Models.DB;
using System.Collections.Generic;

namespace Assignment_2.Repositories
{
    public interface IActorRepository
    {
        void Add(ActorDB actor);
        void Delete(int id);
        ActorDB Get(int id);
        List<ActorDB> GetAll();
    }
}