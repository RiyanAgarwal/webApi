using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assignment_4.Models;
using Assignment_4.Models.DB;
using Assignment_4.Models.Request;
using Assignment_4.Repositories;
using FluentAssertions;
using Moq;

namespace Assignment_4.Test.MockResources
{
    public class MovieMock
    {
        public static readonly Mock<IMovieRepository> MovieRepoMock = new Mock<IMovieRepository>();
        private static readonly List<MovieDB> ListOfMovies = new List<MovieDB>
        {
            new MovieDB
            {
                Id = 1,
                Name = "M1",
                YearOfRelease=2000,
                CoverImage="www",
                Plot="plot1",
                ProducerId=1
            },
            new MovieDB
            {
                Id = 2,
                Name = "M2",
                YearOfRelease=2000,
                CoverImage="www",
                Plot="plot1",
                ProducerId=1
            }
        };
        private static readonly List<int> ListOfMovieActors = new List<int> { 1, 2 };
        private static readonly List<int> ListOfMovieGenres = new List<int> { 1, 2 };
        public static void MockGetAll()
        {
            MovieRepoMock.Setup(x => x.GetAll()).Returns(ListOfMovies);
        }
        public static void MockGet()
        {
            MovieRepoMock.Setup(x => x.Get(It.IsAny<int>())).Returns<int>(x => (x > 0) ? ListOfMovies.Find(z => z.Id == x) : null);
        }
        public static void MockGetActors()
        {
            MovieRepoMock.Setup(x => x.GetActors(It.IsAny<int>())).Returns<int>(x => (x > 0) ? ListOfMovieActors : null);
        }
        public static void MockGetGenres()
        {
            MovieRepoMock.Setup(x => x.GetGenres(It.IsAny<int>())).Returns<int>(x => (x > 0) ? ListOfMovieGenres : null);
        }
        public static void MockAdd()
        {
            MovieRepoMock.Setup(x => x.Add(It.IsAny<MovieRequest>()));
        }
        public static void MockDelete()
        {
            MovieRepoMock.Setup(x => x.Delete(It.IsAny<int>()));
        }
        public static void MockUpdate()
        {
            MovieRepoMock.Setup(x => x.Update(It.IsAny<MovieRequest>(), It.IsAny<int>()));
        }
    }
}