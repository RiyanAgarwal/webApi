using Assignment_2.Models.Request;
using Assignment_2.Models.Response;
using System.Collections.Generic;

namespace Assignment_2.Services
{
    public interface IReviewService
    {
        int Create(RequestReview review);
        void Delete(int id);
        ResponseReview Get(int id);
        List<ResponseReview> GetAll();
        void Update(int id, RequestReview review);
    }
}