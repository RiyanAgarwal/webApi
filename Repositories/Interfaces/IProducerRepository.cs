using Assignment_2.Models.DB;
using Assignment_2.Models.Request;
using System.Collections.Generic;

namespace Assignment_2.Repositories
{
    public interface IProducerRepository
    {
        void Add(ProducerRequest producer, int id);
        void Delete(int id);
        ProducerDB Get(int id);
        List<ProducerDB> GetAll();
    }
}