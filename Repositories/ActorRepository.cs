using Assignment_2.Models.DB;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Assignment_2.Repositories

{
    public class ActorRepository : IActorRepository
    {
        private readonly List<DBActor> _actors;
        public ActorRepository()
        {
            _actors = new List<DBActor>();
        }

        public List<DBActor> GetAll()
        {
 
            return _actors.ToList();
        }
        public DBActor Get(int id)
        {
            return _actors.ToList().Where(x=>x.Id == id).First();
        }

        public void Add(DBActor actor)
        {
            _actors.Add(actor);
        }
        public void Delete(int id)
        {
            _actors.Remove(_actors.ToList().Where(x => x.Id == id).First());
        }
    }

}
