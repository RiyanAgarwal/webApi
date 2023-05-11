using Assignment_4.Test;
using Assignment_4.Test.MockResources;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using TechTalk.SpecFlow;

namespace Assignment_4.Test.StepFiles
{
    [Scope(Feature = "Genres feature")]
    [Binding]
    public class GenreSteps : BaseStepDefinitions
    {
        public GenreSteps(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Mock Repo
                    services.AddScoped(x => GenreMock.GenreRepoMock.Object);
                });
            }))
        {
        }
        [BeforeScenario]
        public static void Mocks()
        {
            GenreMock.MockGetAll();
            GenreMock.MockGet();
            GenreMock.MockDelete();
            GenreMock.MockAdd();
            GenreMock.MockUpdate();

        }
    }
}