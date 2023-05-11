using Assignment_4.Test;
using Assignment_4.Test.MockResources;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using TechTalk.SpecFlow;

namespace Assignment_4.Test.StepFiles
{
    [Scope(Feature = "Movies feature")]
    [Binding]
    public class MovieSteps : BaseStepDefinitions
    {
        public MovieSteps(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Mock Repo
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
            MovieMock.MockGetAll();
            MovieMock.MockDelete();
            MovieMock.MockAdd();
            MovieMock.MockUpdate();
            MovieMock.MockGet();
            ActorMock.MockGet();
            GenreMock.MockGet();
            ProducerMock.MockGet();
            MovieMock.MockGetActors();
            MovieMock.MockGetGenres();
        }
    }
}