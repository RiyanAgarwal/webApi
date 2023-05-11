using Assignment_4.Models.DB;
using Assignment_4.Models.Request;
using Assignment_4.Models.Response;
using Assignment_4.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_4.Services
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
            _reviewRepository.Add(review);
            return _reviewRepository.GetAll().Select(x => x.Id).Max();
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
            var review= _reviewRepository.Get(id);
            if (review == null)
                throw new ArgumentException("Invalid review id");
            return _mapper.Map<ReviewResponse>(review);
        }
        public void Update(int id, ReviewRequest review)
        {
            if (string.IsNullOrEmpty(review.Message))
                throw new ArgumentException("Invalid message");
            _movieService.Get(review.MovieId);
            _reviewRepository.Update(review,id);
        }
    }
}