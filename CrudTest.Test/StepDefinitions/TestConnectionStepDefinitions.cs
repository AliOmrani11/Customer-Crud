using System.Net;

namespace CrudTest.Test.StepDefinitions
{
    [Binding]
    public class TestConnectionStepDefinitions
    {
        private readonly HttpClient _httpClient;
        private HttpResponseMessage _response;

        public TestConnectionStepDefinitions()
        {
            _httpClient = new HttpClient();
        }

        [When(@"I call the API endpoint")]
        public async Task WhenICallTheAPIEndpoint()
        {
            string apiUrl = "https://localhost:7075/api/v1/customer/get-all";
            _response = await _httpClient.GetAsync(apiUrl);
        }

        [Then(@"the response status code should be OK")]
        public async Task ThenTheResponseStatusCodeShouldBeOK()
        {
            _response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
