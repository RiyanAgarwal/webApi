using Assignment_2.Models.DB;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        readonly List<ReviewDB> _reviews;
        public ReviewRepository() => _reviews = new();
        public List<ReviewDB> GetAll() => _reviews.ToList();
        public ReviewDB Get(int id) => _reviews.ToList().Where(x => x.Id == id).FirstOrDefault();
        public void Add(ReviewDB review) => _reviews.Add(review);
        public void Delete(int id)
        {
            _reviews.Remove(_reviews.ToList().Where(x => x.Id == id).First());
        }
    }
}