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
            var maxId = _producerRepository.GetAll().Select(x => x.Id).DefaultIfEmpty(0).Max();
            _producerRepository.Add(producer,maxId+1);
            return maxId + 1;
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
            var producer = _producerRepository.Get(id);
            if (producer == null)
                throw new ArgumentException("Invalid producer id");
            return _mapper.Map<ProducerResponse>(producer);
        }
        public void Update(int id, ProducerRequest producer)
        {
            var producerDB = _producerRepository.Get(id);
            if (producerDB == null)
                throw new ArgumentException("Invalid producer id");
            if (string.IsNullOrEmpty(producer.Name))
                throw new ArgumentException("Invalid name");
            if (string.IsNullOrEmpty(producer.Gender))
                throw new ArgumentException("Invalid gender");
            if (string.IsNullOrEmpty(producer.Bio))
                throw new ArgumentException("Invalid bio");
            if (DateTime.Now < producer.DOB)
                throw new ArgumentException("Invalid date");
            producerDB.Name = producer.Name;
            producerDB.Bio = producer.Bio;
            producerDB.Gender = producer.Gender;
        }
    }
}