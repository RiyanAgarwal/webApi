using Assignment_4.Test;
using Assignment_4.Test.MockResources;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using TechTalk.SpecFlow;

namespace Assignment_4.Test.StepFiles
{
    [Scope(Feature = "Reviews feature")]
    [Binding]
    public class ReviewSteps : BaseStepDefinitions
    {
        public ReviewSteps(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Mock Repo
                    services.AddScoped(x => ReviewMock.ReviewRepoMock.Object);
                    services.AddScoped(x => MovieMock.MovieRepoMock.Object);
                    services.AddScoped(x => ProducerMock.ProducerRepoMock.Object);
                    services.AddScoped(x =>ActorMock.ActorRepoMock.Object);
                    services.AddScoped(x =>GenreMock.GenreRepoMock.Object);
                });
            }))
        { 
        }
        [BeforeScenario]
        public static void Mocks()
        {
            ReviewMock.MockGetAll();
            ReviewMock.MockGet();
            ReviewMock.MockDelete();
            ReviewMock.MockAdd();
            ReviewMock.MockUpdate();
            MovieMock.MockGet();
            ActorMock.MockGet();
            GenreMock.MockGet();
            ProducerMock.MockGet();
            MovieMock.MockGetActors();
            MovieMock.MockGetGenres();
        }
    }
}