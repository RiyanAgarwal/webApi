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
            if (string.IsNullOrEmpty(movie.Name))
                throw new ArgumentException("Invalid name");
            if (string.IsNullOrEmpty(movie.CoverImage))
                throw new ArgumentException("Invalid cover");
            if (string.IsNullOrEmpty(movie.Plot))
                throw new ArgumentException("Invalid plot");
            if (DateTime.Now.Year < movie.YearOfRelease)
                throw new ArgumentException("Invalid date");
            _producerService.Get(movie.ProducerId);
            var genresList = movie.GenresIds.Split(",").Select(x=>int.Parse(x)).ToList();
            var actorsList = movie.ActorsIds.Split(",").Select(x=>int.Parse(x)).ToList();            
            foreach (var actorId in actorsList)
            {
                _actorService.Get(actorId);
            }
            foreach (var genreId in genresList)
            {
                _genreService.Get(genreId);
            }
            _movieRepository.Add(movie);
            return _movieRepository.GetAll().Select(x => x.Id).Max();
        }

        public void Delete(int id)
        {
            if (_movieRepository.Get(id) == null)
                throw new ArgumentException("Invalid movie id");
            _movieRepository.Delete(id);
        }

        public List<MovieResponse> GetAll()
        {
            var movieList=_movieRepository.GetAll();
            var responseMovieList=_mapper.Map<List<MovieResponse>>(movieList);
            for(var i=0;i<movieList.Count;i+=1)
            {
                var actorResponse = new List<ActorResponse>();
                var genreResponse = new List<GenreResponse>();
                foreach (var actorId in _movieRepository.GetActors(movieList[i].Id))
                {
                    actorResponse.Add(_actorService.Get(actorId));
                }
                foreach (var genreId in _movieRepository.GetGenres(movieList[i].Id))
                {
                    genreResponse.Add(_genreService.Get(genreId));
                }
                responseMovieList[i].Actors = actorResponse;
                responseMovieList[i].Genres = genreResponse;
                responseMovieList[i].Producer = _producerService.Get(movieList[i].ProducerId);
            }
                return responseMovieList;
        }

        public MovieResponse Get(int id)
        {
            var movieDB = _movieRepository.Get(id);
            if (movieDB == null)
                throw new ArgumentException("Invalid movie id");
            var movieResponse=_mapper.Map<MovieResponse>(movieDB);
            var actorResponse = new List<ActorResponse>();
            var genreResponse = new List<GenreResponse>();
            foreach(var actorId in _movieRepository.GetActors(id))
            {
                actorResponse.Add(_actorService.Get(actorId));
            }
            foreach (var genreId in _movieRepository.GetGenres(id))
            {
                genreResponse.Add(_genreService.Get(genreId));
            }
            movieResponse.Producer = _producerService.Get(movieDB.ProducerId);
            movieResponse.Actors= actorResponse;
            movieResponse.Genres= genreResponse;
            return movieResponse;
        }

        public void Update(int id, MovieRequest movie)
        {
            if (_movieRepository.Get(id) == null)
                throw new ArgumentException("Invalid movie id");
            if (string.IsNullOrEmpty(movie.Name))
                throw new ArgumentException("Invalid name");
            if (string.IsNullOrEmpty(movie.CoverImage))
                throw new ArgumentException("Invalid cover");
            if (string.IsNullOrEmpty(movie.Plot))
                throw new ArgumentException("Invalid plot");
            if (DateTime.Now.Year < movie.YearOfRelease)
                throw new ArgumentException("Invalid date");
            var genresList = movie.GenresIds.Split(",").Select(x => int.Parse(x)).ToList();
            var actorsList = movie.ActorsIds.Split(",").Select(x => int.Parse(x)).ToList();
            foreach (var actorId in actorsList)
            {
                _actorService.Get(actorId);
            }
            foreach (var genreId in genresList)
            {
                _genreService.Get(genreId);
            }
            _movieRepository.Update(movie,id);
        }

        public void UpdateCoverImage(int movieId,string imageURl)
        {
            if (_movieRepository.Get(movieId)==null)
                throw new ArgumentException("Invalid Movie Id");
            _movieRepository.UpdateCoverImage(movieId, imageURl);
        }
    }
}