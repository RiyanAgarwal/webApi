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
            var maxId = _actorRepository.GetAll().Select(x => x.Id).DefaultIfEmpty(0).Max();
            _actorRepository.Add(actor,maxId+1);
            return maxId+1;
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
            var actor = _actorRepository.Get(id);
            if (actor == null)
                throw new ArgumentException("Invalid Actor id");
            return _mapper.Map<ActorResponse>(actor);
        }
        public void Update(int id, ActorRequest actor)
        {
            var actorDB = _actorRepository.Get(id);
            if (string.IsNullOrEmpty(actor.Name))
                throw new ArgumentException("Invalid name");
            if (string.IsNullOrEmpty(actor.Gender))
                throw new ArgumentException("Invalid gender");
            if (string.IsNullOrEmpty(actor.Bio))
                throw new ArgumentException("Invalid bio");
            if (DateTime.Now < actor.DOB)
                throw new ArgumentException("Invalid date");
            if (actorDB == null)
                throw new ArgumentException("Invalid actor id");
            actorDB.Name = actor.Name;
            actorDB.Bio = actor.Bio;
            actorDB.Gender = actor.Gender;
        }
    }
}