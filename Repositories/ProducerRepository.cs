using Assignment_2.Models.DB;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Assignment_2.Repositories

{
    public class ProducerRepository : IProducerRepository
    {
        private readonly List<DBProducer> _producers;
        public ProducerRepository()
        {
            _producers = new List<DBProducer>();
        }

        public List<DBProducer> GetAll()
        {
            if (_producers == null)
            {
                throw new ArgumentNullException("Producers list is empty");
            }
            return _producers.ToList();
        }
        public DBProducer Get(int id)
        {
            var producerWithId = from producer in _producers
                                 where producer.Id == id
                                 select producer;
            if (producerWithId.Count() != 1)
            {
                throw new ArgumentOutOfRangeException("Invalid producer id");
            }
            return producerWithId.First();
        }

        public void Add(DBProducer producer)
        {
            _producers.Add(producer);
        }
        public void Delete(int id)
        {
            var producerWithId = from producer in _producers
                                 where producer.Id == id
                                 select producer;
            if (producerWithId.Count() != 1)
            {
                throw new ArgumentOutOfRangeException("Invalid producer id");
            }
            _producers.Remove(producerWithId.First());
        }
    }

}
