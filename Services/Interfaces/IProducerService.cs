using Assignment_2.Models.Request;
using Assignment_2.Models.Response;
using System.Collections.Generic;

namespace Assignment_2.Services
{
    public interface IProducerService
    {
        int Create(ProducerRequest producer);
        void Delete(int id);
        ProducerResponse Get(int id);
        List<ProducerResponse> GetAll();
        void Update(int id, ProducerRequest producer);
    }
}