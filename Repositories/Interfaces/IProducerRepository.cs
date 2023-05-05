using Assignment_3.Models.DB;
using Assignment_3.Models.Request;
using System.Collections.Generic;

namespace Assignment_3.Repositories
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