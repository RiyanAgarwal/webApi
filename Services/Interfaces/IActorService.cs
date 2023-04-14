using Assignment_2.Models.Request;
using Assignment_2.Models.Response;
using System.Collections.Generic;

namespace Assignment_2.Services
{
        public interface IActorService
        {
            List<ResponseActor> GetAll();
            ResponseActor Get(int id);
            int Create(RequestActor actor);
            void Update(int id,RequestActor actor);
            void Delete(int id);
        }
    }
