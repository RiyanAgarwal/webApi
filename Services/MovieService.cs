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
        readonly IMovieRepository _movieRepository;
        readonly IMapper _mapper;
        readonly IProducerService _producerService;
        readonly IActorService _actorService;
        readonly IGenreService _genreService;
        public MovieService(IMovieRepository movieRepository,
            IMapper mapper,
            IProducerService producerService,
            IActorService actorService,
            IGenreService genreService)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _producerService = producerService;
            _actorService = actorService;
            _genreService = genreService;
        }
        public int Create(MovieRequest movie)
        {
            if (string.IsNullOrEmpty(movie.Name) ||
                string.IsNullOrEmpty(movie.CoverImage) ||
                string.IsNullOrEmpty(movie.Plot) ||
                DateTime.Now.Year < movie.YearOfRelease)
                throw new ArgumentException("Invalid data");

            if (!_mapper.Map<List<ProducerRequest>>(_producerService.GetAll())
                .Any(x=>x.Name==movie.Producer.Name &&
                    x.DOB==movie.Producer.DOB &&
                    x.Bio==movie.Producer.Bio &&
                    x.Gender==movie.Producer.Gender))
            {
                throw new ArgumentException("Producer not found");
            }

            var requestAllGenres = _mapper.Map<List<GenreRequest>>(_genreService.GetAll());

            foreach (var genre in movie.Genres)
            {
                if (!requestAllGenres.Any(x=>x.Name==genre.Name))
                {
                    throw new ArgumentException("Genre not found");
                }
            }

            var requestActors = _mapper.Map<List<ActorRequest>>(_actorService.GetAll());

            foreach (var actor in movie.Actors)
            {
                if (!requestActors.Any(x => x.Name == actor.Name &&
                    x.DOB == actor.DOB &&
                    x.Bio == actor.Bio &&
                    x.Gender == actor.Gender))
                {
                    throw new ArgumentException("Actor not found");
                }
            }

            var maxId = _movieRepository.GetAll().Select(x => x.Id).DefaultIfEmpty(0).Max();
            var movieToBeAdded = _mapper.Map<MovieDB>(movie);
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

        public List<MovieResponse> GetAll()
        {
            return _mapper.Map<List<MovieResponse>>(_movieRepository.GetAll());
        }

        public MovieResponse Get(int id)
        {
            if (_movieRepository.GetAll().Where(x => x.Id == id).Count() != 1)
                throw new ArgumentException("Invalid movie id");

            return _mapper.Map<MovieResponse>(_movieRepository.Get(id));
        }

        public void Update(int id, MovieRequest movie)
        {
            if (_movieRepository.GetAll().Where(x => x.Id == id).Count() != 1)
                throw new ArgumentException("Invalid movie id");

            if (string.IsNullOrEmpty(movie.Name) ||
                string.IsNullOrEmpty(movie.CoverImage) ||
                string.IsNullOrEmpty(movie.Plot) ||
                DateTime.Now.Year < movie.YearOfRelease)
                throw new ArgumentException("Invalid data");

            if (!_mapper.Map<List<ProducerRequest>>(_producerService.GetAll())
                .Any(x => x.Name == movie.Producer.Name &&
                    x.DOB == movie.Producer.DOB &&
                    x.Bio == movie.Producer.Bio &&
                    x.Gender == movie.Producer.Gender))
            {
                throw new ArgumentException("Producer not found");
            }

            var requestAllGenres = _mapper.Map<List<GenreRequest>>(_genreService.GetAll());

            foreach (var genre in movie.Genres)
            {
                if (!requestAllGenres.Any(x => x.Name == genre.Name))
                {
                    throw new ArgumentException("Genre not found");
                }
            }

            var requestActors = _mapper.Map<List<ActorRequest>>(_actorService.GetAll());

            foreach (var actor in movie.Actors)
            {
                if (!requestActors.Any(x => x.Name == actor.Name &&
                    x.DOB == actor.DOB &&
                    x.Bio == actor.Bio &&
                    x.Gender == actor.Gender))
                {
                    throw new ArgumentException("Actor not found");
                }
            }

            _movieRepository.Delete(id);
            var movieToBeAdded = _mapper.Map<MovieDB>(movie);
            movieToBeAdded.Id = id;
            _movieRepository.Add(movieToBeAdded);
        }
    }
}