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
    public class ActorMock
    {
        public static readonly Mock<IActorRepository> ActorRepoMock = new Mock<IActorRepository>();
        private static readonly List<ActorDB> ListOfActors = new List<ActorDB>
        {
            new ActorDB
            {
                Id = 1,
                Name = "Mock Actor 1",
                Bio = "--",
                DOB = DateTime.Now.AddYears(-22)
            },
            new ActorDB
            {
                Id = 2,
                Name = "Mock Actor 2",
                Bio = "--",
                DOB = DateTime.Now.AddYears(-20)
            }
        };

        public static void MockGetAll()
        {
            ActorRepoMock.Setup(x => x.GetAll()).Returns(ListOfActors);
        }
        public static void MockGet()
        {
            ActorRepoMock.Setup(x => x.Get(It.Is<int>(y => y > 0))).Returns(ListOfActors[0]);
        }
        public static void MockAdd()
        {
            ActorRepoMock.Setup(x => x.Add(It.IsAny<ActorRequest>()));
        }
        public static void MockDelete()
        {
            ActorRepoMock.Setup(x => x.Delete(It.Is<int>(y=>y>0)));
        }
        public static void MockUpdate()
        {
            ActorRepoMock.Setup(x => x.Update(It.IsAny<ActorRequest>(), It.IsAny<int>()));
        }
    }
}