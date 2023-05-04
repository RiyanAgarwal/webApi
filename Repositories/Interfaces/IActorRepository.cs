using Assignment_2.Models.DB;
using Assignment_2.Models.Request;
using System.Collections.Generic;

namespace Assignment_2.Repositories
{
    public interface IActorRepository
    {
        void Add(ActorRequest actor, int id);
        void Delete(int id);
        ActorDB Get(int id);
        List<ActorDB> GetAll();
    }
}