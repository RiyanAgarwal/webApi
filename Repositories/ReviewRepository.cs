using Assignment_2.Models.DB;
using Assignment_2.Models.Request;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        readonly List<ReviewDB> _reviews;
        private readonly IMapper _mapper;

        public ReviewRepository(IMapper mapper)
        {
            _mapper = mapper;
            _reviews = new();
        }
        public List<ReviewDB> GetAll() => _reviews.ToList();
        public ReviewDB Get(int id) => _reviews.ToList().Where(x => x.Id == id).FirstOrDefault();
        public void Add(ReviewRequest review, int id)
        {
            var reviewDB = _mapper.Map<ReviewDB>(review);
            reviewDB.Id = id;
            _reviews.Add(reviewDB);
        }
        public void Delete(int id)
        {
            _reviews.Remove(_reviews.ToList().Where(x => x.Id == id).First());
        }
    }
}