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
            if (string.IsNullOrEmpty(producer.Name) ||
                string.IsNullOrEmpty(producer.Gender) ||
                string.IsNullOrEmpty(producer.Bio) ||
                DateTime.Now < producer.DOB)
                throw new ArgumentException("Invalid data");

            var maxId = _producerRepository.GetAll().Select(x => x.Id).DefaultIfEmpty(0).Max();
            var producerToBeAdded = _mapper.Map<ProducerDB>(producer);
            producerToBeAdded.Id = maxId + 1;
            _producerRepository.Add(producerToBeAdded);
            return producerToBeAdded.Id;
        }

        public void Delete(int id)
        {
            if (_producerRepository.GetAll().Where(x => x.Id == id).Count() != 1)
                throw new ArgumentException("Invalid producer id");

            _producerRepository.Delete(id);
        }

        public List<ProducerResponse> GetAll()
        {
            return _mapper.Map<List<ProducerResponse>>(_producerRepository.GetAll());
        }

        public ProducerResponse Get(int id)
        {
            if (_producerRepository.GetAll().Where(x => x.Id == id).Count() != 1)
                throw new ArgumentException("Invalid producer id");

            return _mapper.Map<ProducerResponse>(_producerRepository.Get(id));
        }

        public void Update(int id, ProducerRequest producer)
        {
            if (string.IsNullOrEmpty(producer.Name) ||
                string.IsNullOrEmpty(producer.Gender) ||
                string.IsNullOrEmpty(producer.Bio) ||
                DateTime.Now < producer.DOB)
                throw new ArgumentException("Invalid data");

            if (_producerRepository.GetAll().Where(x => x.Id == id).Count() != 1)
                throw new ArgumentException("Invalid producer id");

            _producerRepository.Delete(id);
            var producerToBeAdded = _mapper.Map<ProducerDB>(producer);
            producerToBeAdded.Id = id;
            _producerRepository.Add(producerToBeAdded);
        }
    }
}