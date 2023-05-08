using Assignment_4.Models.DB;
using Assignment_4.Models.Request;
using System.Collections.Generic;

namespace Assignment_4.Repositories
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