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
    public class GenreMock
    {
        public static readonly Mock<IGenreRepository> GenreRepoMock = new Mock<IGenreRepository>();
        private static readonly List<GenreDB> ListOfGenres = new List<GenreDB>
        {
            new GenreDB
            {
                Id = 1,
                Name = "G1"
            },
            new GenreDB
            {
                Id = 2,
                Name = "G2"
            }
        };
        public static void MockGetAll()
        {
            GenreRepoMock.Setup(x => x.GetAll()).Returns(ListOfGenres);
        }
        public static void MockGet()
        {
            GenreRepoMock.Setup(x => x.Get(It.IsAny<int>())).Returns<int>(x => (x > 0) ? ListOfGenres.Find(z => z.Id == x) : null);
        }
        public static void MockAdd()
        {
            GenreRepoMock.Setup(x => x.Add(It.IsAny<GenreRequest>()));
        }
        public static void MockDelete()
        {
            GenreRepoMock.Setup(x => x.Delete(It.IsAny<int>()));
        }
        public static void MockUpdate()
        {
            GenreRepoMock.Setup(x => x.Update(It.IsAny<GenreRequest>(), It.IsAny<int>()));
        }
    }
}