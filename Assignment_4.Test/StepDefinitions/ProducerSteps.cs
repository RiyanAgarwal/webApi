using Assignment_4.Test;
using Assignment_4.Test.MockResources;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using TechTalk.SpecFlow;

namespace Assignment_4.Test.StepFiles
{
    [Scope(Feature = "Producers feature")]
    [Binding]
    public class ProducerSteps : BaseStepDefinitions
    {
        public ProducerSteps(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Mock Repo
                    services.AddScoped(x => ProducerMock.ProducerRepoMock.Object);
                });
            }))
        { 
        }
        [BeforeScenario]
        public static void Mocks()
        {
            ProducerMock.MockGetAll();
            ProducerMock.MockGet();
            ProducerMock.MockDelete();
            ProducerMock.MockAdd();
            ProducerMock.MockUpdate();

        }
    }
}