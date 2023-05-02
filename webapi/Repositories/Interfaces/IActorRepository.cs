using Assignment_4.Models.DB;
using System.Collections.Generic;

namespace Assignment_4.Repositories
{
    public interface IActorRepository
    {
        void Add(ActorDB actor);
        void Delete(int id);
        ActorDB Get(int id);
        List<ActorDB> GetAll();
        void Update(ActorDB actor);
    }
}