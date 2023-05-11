using Assignment_4.Models.DB;
using Assignment_4.Models.Request;
using System.Collections.Generic;

namespace Assignment_4.Repositories
{
    public interface IActorRepository
    {
        void Add(ActorRequest actor);
        void Delete(int id);
        ActorDB Get(int id);
        List<ActorDB> GetAll();
        void Update(ActorRequest actor, int id);
    }
}