using Assignment_4.Models.DB;
using Assignment_4.Models.Request;
using System.Collections.Generic;

namespace Assignment_4.Repositories
{
    public interface IProducerRepository
    {
        void Add(ProducerRequest Producer);
        void Delete(int id);
        ProducerDB Get(int id);
        List<ProducerDB> GetAll();
        void Update(ProducerRequest producer, int id);
    }
}