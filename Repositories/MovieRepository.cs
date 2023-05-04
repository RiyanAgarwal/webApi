using Assignment_2.Models.DB;
using Assignment_2.Models.Request;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly List<MovieDB> _movies;
        private readonly List<List<int>> _moviesActors;
        private readonly List<List<int>> _moviesGenres;
        private readonly IMapper _mapper;
        public MovieRepository(IMapper mapper)
        {
            _mapper = mapper;
            _movies = new();
            _moviesActors = new();
            _moviesGenres = new();
        }
        public List<MovieDB> GetAll() => _movies.ToList();
        public List<List<int>> GetAllMoviesActors() => _moviesActors;
        public List<List<int>> GetAllMoviesGenres() => _moviesGenres;
        public List<int> GetMovieActors(int id)
        {
            int index = _movies.FindIndex(x => x.Id == id);
            return _moviesActors[index];
        }
        public List<int> GetMovieGenres(int id)
        {
            int index = _movies.FindIndex(x => x.Id == id);
            return _moviesGenres[index];
        }
        public MovieDB Get(int id) => _movies.Where(x => x.Id == id).FirstOrDefault();
        public void Add(MovieRequest movie,int Id)
        {
            _moviesActors.Add(movie.ActorsIds.Split(",").Select(x => int.Parse(x)).ToList());
            _moviesGenres.Add(movie.GenresIds.Split(",").Select(x => int.Parse(x)).ToList());
            var movieDB=_mapper.Map<MovieDB>(movie);
            movieDB.Id = Id;
            _movies.Add(movieDB);
        }
        public void Delete(int id)
        {
            int index = _movies.FindIndex(x => x.Id == id);
            _moviesActors.RemoveAt(index);
            _moviesGenres.RemoveAt(index);
            _movies.RemoveAt(index);
        }
    }
}