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
            if (_reviews == null)
            {
                throw new ArgumentNullException("Reviews list is empty");
            }
            return _reviews.ToList();
        }
        public DBReview Get(int id)
        {
            var reviewWithId = from review in _reviews
                               where review.Id == id
                               select review;
            if (reviewWithId.Count() != 1)
            {
                throw new ArgumentOutOfRangeException("Invalid review id");
            }
            return reviewWithId.First();
        }

        public void Add(DBReview review)
        {
            _reviews.Add(review);
        }
        public void Delete(int id)
        {
            var reviewWithId = from review in _reviews
                               where review.Id == id
                               select review;
            if (reviewWithId.Count() != 1)
            {
                throw new ArgumentOutOfRangeException("Invalid review id");
            }
            _reviews.Remove(reviewWithId.First());
        }
    }

}
