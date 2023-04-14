using Assignment_2.Models.DB;
using Assignment_2.Models.Request;
using Assignment_2.Models.Response;
using Assignment_2.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;
        public ActorService(IActorRepository actorRepository,IMapper mapper)
        { 
            _actorRepository=actorRepository;
            _mapper=mapper;
        }
        public int Create(RequestActor actor)
        {
            if (string.IsNullOrEmpty(actor.Name)|| 
                string.IsNullOrEmpty(actor.Gender)|| 
                string.IsNullOrEmpty(actor.Bio) )
                //DateTime.Now<actor.DOB)
                throw new ArgumentException("Invalid data");
            var maxId= _actorRepository.GetAll().Select(x=>x.Id).DefaultIfEmpty(0).Max();
            var actorToBeAdded = _mapper.Map<DBActor>(actor);
            actorToBeAdded.Id = maxId+1;
            _actorRepository.Add(actorToBeAdded);
            return actorToBeAdded.Id;
        }

        public void Delete(int id)
        {
            if (_actorRepository.GetAll().Where(x => x.Id == id).Count() != 1)
                throw new ArgumentException("Invalid actor id");

            _actorRepository.Delete(id);
        }

        public List<ResponseActor> GetAll()
        {
            if (_actorRepository.GetAll().Count < 1)
            {
                throw new ArgumentNullException("Actors list is empty");
            }
            return _mapper.Map<List<ResponseActor>>(_actorRepository.GetAll());
        }

        public ResponseActor Get(int id)
        {
            if (_actorRepository.GetAll().Where(x=>x.Id==id).Count()!=1)           
                throw new ArgumentException("Invalid actor id");

            return _mapper.Map<ResponseActor>(_actorRepository.Get(id));
        }

        public void Update(int id,RequestActor actor)
        {
            if (string.IsNullOrEmpty(actor.Name) ||
                string.IsNullOrEmpty(actor.Gender) ||
                string.IsNullOrEmpty(actor.Bio) )
                //DateTime.Now < actor.DOB)
                throw new ArgumentException("Invalid data");

            if (_actorRepository.GetAll().Where(x => x.Id == id).Count() != 1)
                throw new ArgumentException("Invalid actor id");

            _actorRepository.Delete(id);
            var actorToBeAdded = _mapper.Map<DBActor>(actor);
            actorToBeAdded.Id = id;
            _actorRepository.Add(actorToBeAdded);
        }

    }
}
