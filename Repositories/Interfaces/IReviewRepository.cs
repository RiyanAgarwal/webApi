using Assignment_3.Models.DB;
using System.Collections.Generic;

namespace Assignment_3.Repositories
{
    public interface IReviewRepository
    {
        void Add(ReviewDB review);
        void Delete(int id);
        ReviewDB Get(int id);
        List<ReviewDB> GetAll();
    }
}