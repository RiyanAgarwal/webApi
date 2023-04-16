using Assignment_2.Models.DB;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2.Repositories
{
    public class ActorRepository : IActorRepository
    {
        readonly List<ActorDB> _actors;
        public ActorRepository() => _actors = new();

        public List<ActorDB> GetAll() => _actors.ToList();

        public ActorDB Get(int id) => _actors.ToList().Where(x => x.Id == id).First();

        public void Add(ActorDB actor) => _actors.Add(actor);

        public void Delete(int id) => _actors.Remove(_actors.ToList().Where(x => x.Id == id).First());
    }
}