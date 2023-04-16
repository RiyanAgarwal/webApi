using Assignment_2.Models.DB;
using System.Collections.Generic;

namespace Assignment_2.Repositories
{
    public interface IReviewRepository
    {
        void Add(ReviewDB review);
        void Delete(int id);
        ReviewDB Get(int id);
        List<ReviewDB> GetAll();
    }
}