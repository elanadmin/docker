using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;
using HostApi;

namespace intigrationtest
{
    
    public class IntegrationTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public IntegrationTest()
        {
            _server = new TestServer(new WebHostBuilder()
                            .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void TestApiValues()
        {
            var response  = await _client.GetAsync("/api/values");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("[\"john\",\"doe\"]",
                    responseString);

        }

        [Fact]
        public async void TestGetValueById()
        {
            var response  = await _client.GetAsync("/api/values/5");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal("john", responseString);
        }
    }
}
