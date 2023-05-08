using Assignment_4.Models.Request;
using Assignment_4.Models.Response;
using System.Collections.Generic;

namespace Assignment_4.Services
{
    public interface IActorService
    {
        List<ActorResponse> GetAll();
        ActorResponse Get(int id);
        int Create(ActorRequest actor);
        void Update(int id, ActorRequest actor);
        void Delete(int id);
    }
}
