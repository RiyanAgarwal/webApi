using Assignment_4.Test;
using Assignment_4.Test.MockResources;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using TechTalk.SpecFlow;

namespace Assignment_4.Test.StepFiles
{
    [Scope(Feature = "Actors feature")]
    [Binding]
    public class ActorSteps : BaseStepDefinitions
    {
        public ActorSteps(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Mock Repo
                    services.AddScoped(x => ActorMock.ActorRepoMock.Object);
                });
            }))
        { 
        }
        [BeforeScenario]
        public static void Mocks()
        {
            ActorMock.MockGetAll();
            ActorMock.MockGet();
        }
    }
}