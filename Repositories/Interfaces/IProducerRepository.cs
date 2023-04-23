using Assignment_3.Models.DB;
using System.Collections.Generic;

namespace Assignment_3.Repositories
{
    public interface IProducerRepository
    {
        void Add(ProducerDB producer);
        void Delete(int id);
        ProducerDB Get(int id);
        List<ProducerDB> GetAll();
    }
}