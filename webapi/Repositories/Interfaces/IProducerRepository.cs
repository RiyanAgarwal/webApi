using Assignment_4.Models.DB;
using System.Collections.Generic;

namespace Assignment_4.Repositories
{
    public interface IProducerRepository
    {
        void Add(ProducerDB producer);
        void Delete(int id);
        ProducerDB Get(int id);
        List<ProducerDB> GetAll();
        void Update(ProducerDB producer);
    }
}