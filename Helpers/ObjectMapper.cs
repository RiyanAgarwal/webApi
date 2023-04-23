using Assignment_3.Models.DB;
using Assignment_3.Models.Request;
using Assignment_3.Models.Response;
using Assignment_3.Services;
using AutoMapper;
using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_3.Helpers
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
            CreateMap<MovieRequest, MovieDB>().ForMember(dest=>dest.ActorsId,src=>src.Ignore()).ForMember(dest => dest.GenresId, src => src.Ignore());
            CreateMap<GenreRequest, GenreDB>();
            CreateMap<GenreDB, GenreResponse>();
            CreateMap<ReviewRequest, ReviewDB>();
            CreateMap<ReviewDB, ReviewResponse>();
        }
    }
}