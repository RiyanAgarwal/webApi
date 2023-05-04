using Assignment_2.Models.DB;
using Assignment_2.Models.Request;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly List<ActorDB> _actors;
        private readonly IMapper _mapper;
        public ActorRepository(IMapper mapper)
        {
            _mapper = mapper;
            _actors = new();
        }
        public List<ActorDB> GetAll() => _actors;
        public ActorDB Get(int id) => _actors.Where(x => x.Id == id).FirstOrDefault();
        public void Add(ActorRequest actor, int id)
        {
            var actorDB = _mapper.Map<ActorDB>(actor);
            actorDB.Id = id;
            _actors.Add(actorDB);
        }
        public void Delete(int id) => _actors.Remove(_actors.ToList().Where(x => x.Id == id).First());
    }
}