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
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public int Create(RequestMovie movie)
        {
            if (string.IsNullOrEmpty(movie.Name) ||
                string.IsNullOrEmpty(movie.CoverImage) ||
                string.IsNullOrEmpty(movie.Plot)||
                DateTime.Now.Year < movie.YearOfRelease||
                movie.Producer==null||
                movie.Actors.Count<1||
                movie.Genres.Count<1)
                    throw new ArgumentException("Invalid data");
            var maxId = _movieRepository.GetAll().Select(x => x.Id).DefaultIfEmpty(0).Max();
            var movieToBeAdded = _mapper.Map<DBMovie>(movie);
            movieToBeAdded.Id = maxId + 1;
            _movieRepository.Add(movieToBeAdded);
            return movieToBeAdded.Id;
        }

        public void Delete(int id)
        {
            if (_movieRepository.GetAll().Where(x => x.Id == id).Count() != 1)
                throw new ArgumentException("Invalid movie id");

            _movieRepository.Delete(id);
        }

        public List<ResponseMovie> GetAll()
        {
            if (_movieRepository.GetAll().Count < 1)
            {
                throw new ArgumentNullException("Movies list is empty");
            }
            return _mapper.Map<List<ResponseMovie>>(_movieRepository.GetAll());
        }

        public ResponseMovie Get(int id)
        {
            if (_movieRepository.GetAll().Where(x => x.Id == id).Count() != 1)
                throw new ArgumentException("Invalid movie id");

            return _mapper.Map<ResponseMovie>(_movieRepository.Get(id));
        }

        public void Update(int id, RequestMovie movie)
        {
            if (string.IsNullOrEmpty(movie.Name) ||
                string.IsNullOrEmpty(movie.CoverImage) ||
                string.IsNullOrEmpty(movie.Plot) ||
                DateTime.Now.Year < movie.YearOfRelease ||
                movie.Producer == null ||
                movie.Actors.Count < 1 ||
                movie.Genres.Count < 1)
                throw new ArgumentException("Invalid data");

            if (_movieRepository.GetAll().Where(x => x.Id == id).Count() != 1)
                throw new ArgumentException("Invalid movie id");

            _movieRepository.Delete(id);
            var movieToBeAdded = _mapper.Map<DBMovie>(movie);
            movieToBeAdded.Id = id;
            _movieRepository.Add(movieToBeAdded);
        }

    }
}
