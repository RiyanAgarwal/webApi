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
    public class ProducerMock
    {
        public static readonly Mock<IProducerRepository> ProducerRepoMock = new Mock<IProducerRepository>();
        private static readonly List<ProducerDB> ListOfProducers = new List<ProducerDB>
        {
            new ProducerDB
            {
                Id = 1,
                Name = "P1",
                Bio = "--",
                DOB =DateTime.Parse("2000-10-10T00:00:00"),
                Gender="male"
            },
            new ProducerDB
            {
                Id = 2,
                Name = "P2",
                Bio = "--",
                DOB =DateTime.Parse("2000-10-10T00:00:00"),
                Gender="male"
            }
        };
        public static void MockGetAll()
        {
            ProducerRepoMock.Setup(x => x.GetAll()).Returns(ListOfProducers);
        }
        public static void MockGet()
        {
            ProducerRepoMock.Setup(x => x.Get(It.IsAny<int>())).Returns<int>(x =>ListOfProducers.Find(z => z.Id == x));
        }
        public static void MockAdd()
        {
            ProducerRepoMock.Setup(x => x.Add(It.IsAny<ProducerRequest>()));
        }
        public static void MockDelete()
        {
            ProducerRepoMock.Setup(x => x.Delete(It.IsAny<int>()));
        }
        public static void MockUpdate()
        {
            ProducerRepoMock.Setup(x => x.Update(It.IsAny<ProducerRequest>(), It.IsAny<int>()));
        }
    }
}