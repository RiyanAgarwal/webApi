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
            var maxId = _movieRepository.GetAll().Select(x => x.Id).DefaultIfEmpty(0).Max();
            _movieRepository.Add(movie,maxId+1);
            return maxId+1;
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
            for(var i=0;i<movieList.Count();i+=1)
            {
                var actorResponse = new List<ActorResponse>();
                var genreResponse = new List<GenreResponse>();
                foreach (var actorId in _movieRepository.GetMovieActors(movieList[i].Id))
                {
                    actorResponse.Add(_actorService.Get(actorId));
                }
                foreach (var genreId in _movieRepository.GetMovieGenres(movieList[i].Id))
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
            var movieActors=_movieRepository.GetMovieActors(id);
            var movieGenres=_movieRepository.GetMovieGenres(id);
            foreach(var actorId in movieActors)
            {
                actorResponse.Add(_actorService.Get(actorId));
            }
            foreach (var genreId in movieGenres)
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
            var movieDB = _movieRepository.Get(id);
            var movieActors = _movieRepository.GetMovieActors(id);
            var movieGenres = _movieRepository.GetMovieGenres(id);
            if (movieDB == null)
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
            movieDB.Name = movie.Name;
            movieDB.Plot = movie.Plot;
            movieDB.CoverImage= movie.CoverImage;
            movieDB.YearOfRelease= movie.YearOfRelease;
            movieDB.ProducerId= movie.ProducerId;
            movieActors.Clear();
            movieActors.AddRange(actorsList);
            movieGenres.Clear();
            movieGenres.AddRange(genresList);
        }
    }
}