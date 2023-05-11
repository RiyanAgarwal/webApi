using Assignment_4.Models.Request;
using Assignment_4.Models.Response;
using System.Collections.Generic;

namespace Assignment_4.Services
{
    public interface IReviewService
    {
        int Create(ReviewRequest review);
        void Delete(int id);
        ReviewResponse Get(int id);
        List<ReviewResponse> GetAll();
        void Update(int id, ReviewRequest review);
    }
}