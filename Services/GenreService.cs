using Assignment_2.Models.DB;
using Assignment_2.Models.Request;
using Assignment_2.Models.Response;
using Assignment_2.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Assignment_2.Services
{
    public class GenreService : IGenreService
    {
        readonly IGenreRepository _genreRepository;
        readonly IMapper _mapper;
        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
        public int Create(GenreRequest genre)
        {
            if (string.IsNullOrEmpty(genre.Name))
                throw new ArgumentException("Invalid name");
            var maxId = _genreRepository.GetAll().Select(x => x.Id).DefaultIfEmpty(0).Max();
            var genreToBeAdded = _mapper.Map<GenreDB>(genre);
            genreToBeAdded.Id = maxId + 1;
            _genreRepository.Add(genreToBeAdded);
            return genreToBeAdded.Id;
        }
        public void Delete(int id)
        {
            if (_genreRepository.Get(id) == null)
                throw new ArgumentException("Invalid genre id");
            _genreRepository.Delete(id);
        }
        public List<GenreResponse> GetAll()
        {
            return _mapper.Map<List<GenreResponse>>(_genreRepository.GetAll());
        }
        public GenreResponse Get(int id)
        {
            if (_genreRepository.Get(id) == null)
                throw new ArgumentException("Invalid genre id");
            return _mapper.Map<GenreResponse>(_genreRepository.Get(id));
        }
        public void Update(int id, GenreRequest genre)
        {
            if(string.IsNullOrEmpty(genre.Name))
                throw new ArgumentException("Invalid name");
            if (_genreRepository.Get(id) == null)
                throw new ArgumentException("Invalid genre id");
            var genreDB = _genreRepository.Get(id);
            genreDB.Name = genre.Name;
        }
    }
}