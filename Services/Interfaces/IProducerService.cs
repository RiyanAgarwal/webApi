using Assignment_2.Models.Request;
using Assignment_2.Models.Response;
using System.Collections.Generic;

namespace Assignment_2.Services
{
    public interface IProducerService
    {
        int Create(RequestProducer producer);
        void Delete(int id);
        ResponseProducer Get(int id);
        List<ResponseProducer> GetAll();
        void Update(int id, RequestProducer producer);
    }
}