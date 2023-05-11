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
    public class ReviewMock
    {
        public static readonly Mock<IReviewRepository> ReviewRepoMock = new Mock<IReviewRepository>();
        private static readonly List<ReviewDB> ListOfReviews = new List<ReviewDB>
        {
            new ReviewDB
            {
                Id = 1,
                MovieId = 1,
                Message = "--",
            },
            new ReviewDB
            {
                Id = 2,
                MovieId =1,
                Message = "--"
            }
        };
        public static void MockGetAll()
        {
            ReviewRepoMock.Setup(x => x.GetAll()).Returns(ListOfReviews);
        }
        public static void MockGet()
        {
            ReviewRepoMock.Setup(x => x.Get(It.IsAny<int>())).Returns<int>(x => (x > 0) ? ListOfReviews.Find(z => z.Id == x) : null);
        }
        public static void MockAdd()
        {
            ReviewRepoMock.Setup(x => x.Add(It.IsAny<ReviewRequest>()));
        }
        public static void MockDelete()
        {
            ReviewRepoMock.Setup(x => x.Delete(It.IsAny<int>()));
        }
        public static void MockUpdate()
        {
            ReviewRepoMock.Setup(x => x.Update(It.IsAny<ReviewRequest>(), It.IsAny<int>()));
        }
    }
}