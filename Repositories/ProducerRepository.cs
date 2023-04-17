using Assignment_2.Models.DB;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2.Repositories
{
    public class ProducerRepository : IProducerRepository
    {
        readonly List<ProducerDB> _producers;
        public ProducerRepository() => _producers = new();
        public List<ProducerDB> GetAll() => _producers.ToList();
        public ProducerDB Get(int id) => _producers.ToList().Where(x => x.Id == id).FirstOrDefault();
        public void Add(ProducerDB producer) => _producers.Add(producer);
        public void Delete(int id)
        {
            _producers.Remove(_producers.ToList().Where(x => x.Id == id).First());
        }
    }
}