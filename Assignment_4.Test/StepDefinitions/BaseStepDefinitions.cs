using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using TechTalk.SpecFlow;
using Xunit;

namespace Assignment_4.Test.StepFiles
{
    public class BaseStepDefinitions
    {
        protected WebApplicationFactory<TestStartup> Factory;
        protected HttpClient Client { get; set; }
        protected HttpResponseMessage Response { get; set; }
        protected string InputData { get; set; }
        public BaseStepDefinitions(WebApplicationFactory<TestStartup> baseFactory)
        {
            Factory = baseFactory;
        }

        [BeforeScenario]
        public void InitializeClient()
        {
            Client = Factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri($"http://localhost/")
            });
        }

        [When(@"a GET request is made '(.*)'")]
        public virtual async Task MakeGet(string resourceEndpoint)
        {
            var uri = new Uri(resourceEndpoint, UriKind.Relative);
            Response = await Client.GetAsync(uri);
        }

        [Then(@"status code '(.*)' is returned")]
        public void ResponseCodeCompare(string statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)(int.Parse(statusCode));
            Assert.Equal(expectedStatusCode, Response.StatusCode);
        }

        [Then(@"the response must be '(.*)'")]
        public void CompareResponseData(string p0)
        {
            var responseData = Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Assert.Equal(p0, responseData);
        }
        [Given (@"the following data is entered '(.*)'")]
        public void DataIsEntered(string p0)
        {
            InputData=p0;
        }
        [When(@"a PUT request is made '(.*)'")]
        public virtual async Task MakePut(string resourceEndPoint)
        {
            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            var content = new StringContent(InputData, Encoding.UTF8, "application/json");
            Response = await Client.PutAsync(postRelativeUri, content);
        }

        [When(@"a POST request is made '(.*)'")]
        public virtual async Task MakePost(string resourceEndPoint)
        {
            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            var content = new StringContent(InputData, Encoding.UTF8, "application/json");
            Response = await Client.PostAsync(postRelativeUri, content);
        }

        [When(@"a DELETE request is made '([^']*)'")]
        public virtual async Task MakeDelete(string resourceEndPoint)
        {
            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            Response = await Client.DeleteAsync(postRelativeUri);
        }
    }
}
