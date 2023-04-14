using Assignment_2.Models.DB;
using Assignment_2.Models.Request;
using Assignment_2.Models.Response;
using Assignment_2.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }
        public int Create(RequestReview review)
        {
            if (string.IsNullOrEmpty(review.Message) || 
                !(_movieRepository.GetAll().Select(x=>x.Id).Contains(review.MovieId)))
                    throw new ArgumentException("Invalid data");
            var maxId = _reviewRepository.GetAll().Select(x => x.Id).DefaultIfEmpty(0).Max();
            var reviewToBeAdded = _mapper.Map<DBReview>(review);
            reviewToBeAdded.Id = maxId + 1;
            _reviewRepository.Add(reviewToBeAdded);
            return reviewToBeAdded.Id;
        }

        public void Delete(int id)
        {
            if (_reviewRepository.GetAll().Where(x => x.Id == id).Count() != 1)
                throw new ArgumentException("Invalid review id");

            _reviewRepository.Delete(id);
        }

        public List<ResponseReview> GetAll()
        {
            if (_reviewRepository.GetAll().Count < 1)
            {
                throw new ArgumentNullException("Reviews list is empty");
            }
            return _mapper.Map<List<ResponseReview>>(_reviewRepository.GetAll());
        }

        public ResponseReview Get(int id)
        {
            if (_reviewRepository.GetAll().Where(x => x.Id == id).Count() != 1)
                throw new ArgumentException("Invalid review id");

            return _mapper.Map<ResponseReview>(_reviewRepository.Get(id));
        }

        public void Update(int id, RequestReview review)
        {
            if (string.IsNullOrEmpty(review.Message) ||
                !(_movieRepository.GetAll().Select(x => x.Id).Contains(review.MovieId)))
                    throw new ArgumentException("Invalid data");

            if (_reviewRepository.GetAll().Where(x => x.Id == id).Count() != 1)
                throw new ArgumentException("Invalid review id");

            _reviewRepository.Delete(id);
            var reviewToBeAdded = _mapper.Map<DBReview>(review);
            reviewToBeAdded.Id = id;
            _reviewRepository.Add(reviewToBeAdded);
        }

    }
}
