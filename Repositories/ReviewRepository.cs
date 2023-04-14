using Assignment_2.Models.DB;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Assignment_2.Repositories

{
    public class ReviewRepository : IReviewRepository
    {
        private readonly List<DBReview> _reviews;
        public ReviewRepository()
        {
            _reviews = new List<DBReview>();
        }

        public List<DBReview> GetAll()
        {

            return _reviews.ToList();
        }
        public DBReview Get(int id)
        {
            return _reviews.ToList().Where(x => x.Id == id).First();
        }

        public void Add(DBReview review)
        {
            _reviews.Add(review);
        }
        public void Delete(int id)
        {
            _reviews.Remove(_reviews.ToList().Where(x => x.Id == id).First());
        }
    }

}
