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
        readonly IReviewRepository _reviewRepository;
        readonly IMapper _mapper;
        readonly IMovieService _movieService;
        public ReviewService(IReviewRepository reviewRepository, IMapper mapper, IMovieService movieService)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _movieService = movieService;
        }
        public int Create(ReviewRequest review)
        {
            if (string.IsNullOrEmpty(review.Message))
                throw new ArgumentException("Invalid message");
            _movieService.Get(review.MovieId);
            var maxId = _reviewRepository.GetAll().Select(x => x.Id).DefaultIfEmpty(0).Max();
            var reviewToBeAdded = _mapper.Map<ReviewDB>(review);
            reviewToBeAdded.Id = maxId + 1;
            _reviewRepository.Add(reviewToBeAdded);
            return reviewToBeAdded.Id;
        }

        public void Delete(int id)
        {
            if (_reviewRepository.Get(id) == null)
                throw new ArgumentException("Invalid review id");
            _reviewRepository.Delete(id);
        }
        public List<ReviewResponse> GetAll()
        {
            return _mapper.Map<List<ReviewResponse>>(_reviewRepository.GetAll());
        }
        public ReviewResponse Get(int id)
        {
            if (_reviewRepository.Get(id) == null)
                throw new ArgumentException("Invalid review id");
            return _mapper.Map<ReviewResponse>(_reviewRepository.Get(id));
        }
        public void Update(int id, ReviewRequest review)
        {
            if (string.IsNullOrEmpty(review.Message))
                throw new ArgumentException("Invalid message");
            _movieService.Get(review.MovieId);
            var reviewDB = _reviewRepository.Get(id);
            reviewDB.Message = review.Message;
            reviewDB.MovieId= review.MovieId;
        }
    }
}