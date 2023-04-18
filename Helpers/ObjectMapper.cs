using Assignment_2.Models.DB;
using Assignment_2.Models.Request;
using Assignment_2.Models.Response;
using Assignment_2.Services;
using AutoMapper;
using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2.Helpers
{
    public class ObjectMapper : Profile
    {
        public ObjectMapper()
        { 
            CreateMap<ActorRequest, ActorDB>();
            CreateMap<ActorDB, ActorResponse>();
            CreateMap<ProducerDB, ProducerResponse>();
            CreateMap<ProducerRequest, ProducerDB>();
            CreateMap<MovieDB, MovieResponse>();
            CreateMap<MovieRequest, MovieDB>().
                ForMember(dest => dest.ActorsId, src => src.Ignore()).
                ForMember(dest => dest.GenresId, src => src.Ignore());
            CreateMap<GenreRequest, GenreDB>();
            CreateMap<GenreDB, GenreResponse>();
            CreateMap<ReviewRequest, ReviewDB>();
            CreateMap<ReviewDB, ReviewResponse>();
        }
    }
}