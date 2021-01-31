using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace RESToran.IntegrationTest
{
    public class AppetizerTests
    {
        private readonly HttpClient _client;

        public AppetizerTests() 
        {
            var server = new TestServer(new WebHostBuilder()
                                .UseStartup<Startup>()
                                .UseUrls("http://localhost:5002"));
            
            //var appFactory = new WebApplicationFactory<Startup>();
            _client = server.CreateClient();
        }

        [Fact]
        public async Task AppetizersGetAllTestAsync()
        {
/*
            // Act
            var response = await _client.GetAsync("/Appetizer/Restaurant/desktopApp/all");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.Equal("Hello World!", responseString);*/

            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "/Appetizer/Restaurant/desktopApp/all");
            request.Headers.Add("Authorization", "Basic cG9zdG1hbkBuZXN0by5ocjpQb3N0bWFuIHBhc3M=");
            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

           //var response = _client.GetAsync("http://localhost:5001/Appetizer/Restaurant/desktopApp/all");
        }
    }

}
