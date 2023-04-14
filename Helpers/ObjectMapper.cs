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
          
            CreateMap<RequestActor,DBActor>();
            CreateMap< DBActor,ResponseActor>();

            CreateMap<DBProducer, ResponseProducer>();
            CreateMap<RequestProducer, DBProducer>();

            CreateMap<DBMovie, ResponseMovie>();
            CreateMap<RequestMovie, DBMovie>();

            CreateMap<RequestGenre, DBGenre>();
            CreateMap<DBGenre,ResponseGenre>();

            CreateMap<RequestReview, DBReview>();
            CreateMap<DBReview,ResponseReview>();

        }
    }
}
