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

            return _producers.ToList();
        }
        public DBProducer Get(int id)
        {
            return _producers.ToList().Where(x => x.Id == id).First();
        }

        public void Add(DBProducer producer)
        {
            _producers.Add(producer);
        }
        public void Delete(int id)
        {
            _producers.Remove(_producers.ToList().Where(x => x.Id == id).First());
        }
    }

}
