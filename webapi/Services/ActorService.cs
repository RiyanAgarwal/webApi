using Assignment_3.Models.DB;
using Assignment_3.Models.Request;
using Assignment_3.Models.Response;
using Assignment_3.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_3.Services
{
    public class ActorService : IActorService
    {
        readonly IActorRepository _actorRepository;
        readonly IMapper _mapper;
        public ActorService(IActorRepository actorRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }
        public int Create(ActorRequest actor)
        {
            if (string.IsNullOrEmpty(actor.Name))
                throw new ArgumentException("Invalid name");
            if (string.IsNullOrEmpty(actor.Gender))
                throw new ArgumentException("Invalid gender");
            if (string.IsNullOrEmpty(actor.Bio))
                throw new ArgumentException("Invalid bio");
            if (DateTime.Now < actor.DOB)
                throw new ArgumentException("Invalid date");
            var actorToBeAdded = _mapper.Map<ActorDB>(actor);
            _actorRepository.Add(actorToBeAdded);
            return _actorRepository.GetAll().Select(x => x.Id).Max();
        }
        public void Delete(int id)
        {
            if (_actorRepository.Get(id) == null)
                throw new ArgumentException("Invalid actor id");
            _actorRepository.Delete(id);
        }
        public List<ActorResponse> GetAll()
        {
            return _mapper.Map<List<ActorResponse>>(_actorRepository.GetAll());
        }
        public ActorResponse Get(int id)
        {
            if (_actorRepository.Get(id) == null)
                throw new ArgumentException("Invalid Actor id");
            return _mapper.Map<ActorResponse>(_actorRepository.Get(id));
        }
        public void Update(int id, ActorRequest actor)
        {
            if (string.IsNullOrEmpty(actor.Name))
                throw new ArgumentException("Invalid name");
            if (string.IsNullOrEmpty(actor.Gender))
                throw new ArgumentException("Invalid gender");
            if (string.IsNullOrEmpty(actor.Bio))
                throw new ArgumentException("Invalid bio");
            if (DateTime.Now < actor.DOB)
                throw new ArgumentException("Invalid date");
            if (_actorRepository.Get(id) == null)
                throw new ArgumentException("Invalid actor id");
            var actorDB=_mapper.Map<ActorDB>(actor);
            actorDB.Id = id;
            _actorRepository.Update(actorDB);
        }
    }
}