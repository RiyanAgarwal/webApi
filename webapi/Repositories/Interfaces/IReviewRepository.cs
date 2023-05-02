using Assignment_4.Models.DB;
using System.Collections.Generic;

namespace Assignment_4.Repositories
{
    public interface IReviewRepository
    {
        void Add(ReviewDB review);
        void Delete(int id);
        ReviewDB Get(int id);
        List<ReviewDB> GetAll();
        void Update(ReviewDB review);
    }
}