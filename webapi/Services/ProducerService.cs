using Assignment_4.Models.DB;
using Assignment_4.Models.Request;
using Assignment_4.Models.Response;
using Assignment_4.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_4.Services
{
    public class ProducerService : IProducerService
    {
        readonly IProducerRepository _producerRepository;
        readonly IMapper _mapper;
        public ProducerService(IProducerRepository producerRepository, IMapper mapper)
        {
            _producerRepository = producerRepository;
            _mapper = mapper;
        }
        public int Create(ProducerRequest producer)
        {
            if (string.IsNullOrEmpty(producer.Name))
                throw new ArgumentException("Invalid name");
            if (string.IsNullOrEmpty(producer.Gender))
                throw new ArgumentException("Invalid gender");
            if (string.IsNullOrEmpty(producer.Bio))
                throw new ArgumentException("Invalid bio");
            if (DateTime.Now < producer.DOB)
                throw new ArgumentException("Invalid date");
            var producerToBeAdded = _mapper.Map<ProducerDB>(producer);
            _producerRepository.Add(producerToBeAdded);
            return _producerRepository.GetAll().Select(x => x.Id).Max();
        }
        public void Delete(int id)
        {
            if (_producerRepository.Get(id) == null)
                throw new ArgumentException("Invalid producer id");
            _producerRepository.Delete(id);
        }
        public List<ProducerResponse> GetAll()
        {
            return _mapper.Map<List<ProducerResponse>>(_producerRepository.GetAll());
        }
        public ProducerResponse Get(int id)
        {
            if (_producerRepository.Get(id) == null)
                throw new ArgumentException("Invalid producer id");
            return _mapper.Map<ProducerResponse>(_producerRepository.Get(id));
        }
        public void Update(int id, ProducerRequest producer)
        {
            if (_producerRepository.Get(id) == null)
                throw new ArgumentException("Invalid producer id");
            if (string.IsNullOrEmpty(producer.Name))
                throw new ArgumentException("Invalid name");
            if (string.IsNullOrEmpty(producer.Gender))
                throw new ArgumentException("Invalid gender");
            if (string.IsNullOrEmpty(producer.Bio))
                throw new ArgumentException("Invalid bio");
            if (DateTime.Now < producer.DOB)
                throw new ArgumentException("Invalid date");
            var producerDB=_mapper.Map<ProducerDB>(producer);
            producerDB.Id = id;
            _producerRepository.Update(producerDB);
        }
    }
}