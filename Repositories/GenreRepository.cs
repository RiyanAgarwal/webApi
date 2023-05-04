using Assignment_2.Models.DB;
using Assignment_2.Models.Request;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        readonly List<GenreDB> _genres;
        private readonly IMapper _mapper;

        public GenreRepository(IMapper mapper)
        {
            _mapper = mapper;
            _genres = new();
        }
        public List<GenreDB> GetAll() => _genres.ToList();
        public GenreDB Get(int id) => _genres.ToList().Where(x => x.Id == id).FirstOrDefault();
        public void Add(GenreRequest genre, int id)
        {
            var genreDB = _mapper.Map<GenreDB>(genre);
            genreDB.Id = id;
            _genres.Add(genreDB);
        }
        public void Delete(int id) => _genres.Remove(_genres.ToList().Where(x => x.Id == id).First());
    }
}