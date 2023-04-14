using Assignment_2.Models.DB;
using System.Collections.Generic;

namespace Assignment_2.Repositories
{
    public interface IProducerRepository
    {
        void Add(DBProducer producer);
        void Delete(int id);
        DBProducer Get(int id);
        List<DBProducer> GetAll();
    }
}