using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;
using HostApi;

namespace intigrationtest
{
    
    public class ProductTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ProductTest()
        {
            _server = new TestServer(new WebHostBuilder()
                            .UseStartup<Startup>());
            _client = _server.CreateClient();
        }


        [Fact]
        public async void Product_GetList_Test()
        {
            var response  = await _client.GetAsync("/api/product");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("[\"product1\"]",
                    responseString);

        }

        [Fact]
        public async void Product_GetById_Test()
        {
            var response  = await _client.GetAsync("/api/product/5");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal("product1", responseString);
        } 

    }
}