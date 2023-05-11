using Assignment_4.Models.DB;
using Assignment_4.Models.Request;
using Assignment_4.Models.Response;
using Assignment_4.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Assignment_4.Services
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
            _genreRepository.Add(genre);
            return _genreRepository.GetAll().Select(x => x.Id).Max();
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
            var genre= _genreRepository.Get(id);
            if (genre == null)
                throw new ArgumentException("Invalid genre id");
            return _mapper.Map<GenreResponse>(genre);
        }
        public void Update(int id, GenreRequest genre)
        {
            if(string.IsNullOrEmpty(genre.Name))
                throw new ArgumentException("Invalid name");
            if (_genreRepository.Get(id) == null)
                throw new ArgumentException("Invalid genre id");
            _genreRepository.Update(genre,id);
        }
    }
}