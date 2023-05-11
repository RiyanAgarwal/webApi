﻿using Assignment_4.Models.DB;
using Assignment_4.Models.Request;
using Assignment_4.Models.Response;
using Assignment_4.Services;
using AutoMapper;
using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_4.Helpers
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
            CreateMap<MovieRequest, MovieDB>();
            CreateMap<GenreRequest, GenreDB>();
            CreateMap<GenreDB, GenreResponse>();
            CreateMap<ReviewRequest, ReviewDB>();
            CreateMap<ReviewDB, ReviewResponse>();
        }
    }
}