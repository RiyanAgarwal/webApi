using Assignment_3.Models.DB;
using Assignment_3.Models.Request;
using System.Collections.Generic;

namespace Assignment_3.Repositories
{
    public interface IReviewRepository
    {
        void Add(ReviewRequest Review);
        void Delete(int id);
        ReviewDB Get(int id);
        List<ReviewDB> GetAll();
        void Update(ReviewRequest review, int id);
    }
}