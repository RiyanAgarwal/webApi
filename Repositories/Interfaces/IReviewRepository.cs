using Assignment_2.Models.DB;
using Assignment_2.Models.Request;
using System.Collections.Generic;

namespace Assignment_2.Repositories
{
    public interface IReviewRepository
    {
        void Add(ReviewRequest review, int id);
        void Delete(int id);
        ReviewDB Get(int id);
        List<ReviewDB> GetAll();
    }
}