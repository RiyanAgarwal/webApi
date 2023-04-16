using Assignment_2.Models.DB;
using System.Collections.Generic;

namespace Assignment_2.Repositories
{
    public interface IProducerRepository
    {
        void Add(ProducerDB producer);
        void Delete(int id);
        ProducerDB Get(int id);
        List<ProducerDB> GetAll();
    }
}