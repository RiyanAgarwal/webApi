using Assignment_2.Models.DB;
using Assignment_2.Models.Request;
using Assignment_2.Models.Response;
using AutoMapper;

namespace Assignment_2.Helpers
{
    public class ObjectMapper : Profile
    {
        public ObjectMapper()
        {
            CreateMap<ActorRequest, ActorDB>();
            CreateMap<ActorDB, ActorResponse>();
            CreateMap<ActorResponse, ActorRequest>();
            CreateMap<ProducerDB, ProducerResponse>();
            CreateMap<ProducerRequest, ProducerDB>();
            CreateMap<ProducerResponse, ProducerRequest>();
            CreateMap<MovieDB, MovieResponse>();
            CreateMap<MovieRequest, MovieDB>();
            CreateMap<GenreRequest, GenreDB>();
            CreateMap<GenreDB, GenreResponse>();
            CreateMap<GenreResponse, GenreRequest>();
            CreateMap<ReviewRequest, ReviewDB>();
            CreateMap<ReviewDB, ReviewResponse>();
        }
    }
}