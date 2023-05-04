using Assignment_2.Models.DB;
using Assignment_2.Models.Request;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2.Repositories
{
    public class ProducerRepository : IProducerRepository
    {
        readonly List<ProducerDB> _producers;
        private readonly IMapper _mapper;

        public ProducerRepository(IMapper mapper)
        {
            _mapper = mapper;
            _producers = new();
        }
        public List<ProducerDB> GetAll() => _producers.ToList();
        public ProducerDB Get(int id) => _producers.ToList().Where(x => x.Id == id).FirstOrDefault();
        public void Add(ProducerRequest producer, int id)
        {
            var producerDB = _mapper.Map<ProducerDB>(producer);
            producerDB.Id = id;
            _producers.Add(producerDB);
        }
        public void Delete(int id)
        {
            _producers.Remove(_producers.ToList().Where(x => x.Id == id).First());
        }
    }
}