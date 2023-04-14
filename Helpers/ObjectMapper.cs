using Assignment_2.Models.DB;
using Assignment_2.Models.Response;
using Assignment_2.Models.Request;
using AutoMapper;
using System;
using Microsoft.VisualBasic;
using System.Globalization;

namespace Assignment_2.Helpers
{
    public class ObjectMapper:Profile
    {
        public ObjectMapper()
        {
          
            CreateMap<RequestActor,DBActor>().ReverseMap();
            CreateMap< DBActor,ResponseActor>();

            CreateMap<DBProducer, ResponseProducer>();
            CreateMap<RequestProducer, DBProducer>().ReverseMap();

            CreateMap<DBMovie, ResponseMovie>();
            CreateMap<RequestMovie, DBMovie>().ReverseMap();

            CreateMap<RequestGenre, DBGenre>().ReverseMap();
            CreateMap<DBGenre,ResponseGenre>();

            CreateMap<RequestReview, DBReview>().ReverseMap();
            CreateMap<DBReview,ResponseReview>();

        }
    }
}
