using Assignment_2.Models.DB;
using System.Collections.Generic;

namespace Assignment_2.Repositories
{
    public interface IReviewRepository
    {
        void Add(DBReview review);
        void Delete(int id);
        DBReview Get(int id);
        List<DBReview> GetAll();
    }
}