using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using RESToran.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Priority;

namespace RESToran.IntegrationTest
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class APITests
    {
        private readonly HttpClient _client;
        private string restaurantEmailAddress = "testrest@mail";
        private string restaurantPassword = "testPassword";
        private string authorizationValue = "dGVzdHJlc3RAbWFpbDp0ZXN0UGFzc3dvcmQ=";

        public APITests() 
        {
            var server = new TestServer(new WebHostBuilder()
                                .UseStartup<Startup>()
                                .UseUrls("http://localhost:5002"));
            
            //var appFactory = new WebApplicationFactory<Startup>();
            _client = server.CreateClient();
            
        }

        // CREATE NEW RESTAURANT AND SAVE ITS EMAIL AND PASSWORD
        [Fact, Priority(0)]
        public async Task CreateNewRestaurant()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5002/Restaurant/create");

            Restaurant restaurant = new Restaurant
            {
                Name = "Test Restaurant",
                EmailAddress = restaurantEmailAddress,
                Password = restaurantPassword,
                Location = "test location",
                PhoneNumber = "01222",
                HoursOpened = "08:00-16:00"
            };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(restaurant);

            // create new restaurant
            request.Content = new StringContent(json,
                                    Encoding.UTF8,
                                    "application/json");

            var response = await _client.SendAsync(request);

            // ASSERT TEST TO BE CREATED
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        // TEST LOGIN FUNCTIONALITY AND GET AUTHORIZATION 
        [Fact, Priority(1)]
        public async Task LoginAsRestaurant()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5002/Restaurant/login");

            Restaurant_Auth restaurantAuth = new Restaurant_Auth
            {
                EmailAddress = restaurantEmailAddress,
                Password = restaurantPassword,
               
            };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(restaurantAuth);

            
            request.Content = new StringContent(json,
                                    Encoding.UTF8,
                                    "application/json");

            var response = await _client.SendAsync(request);
            IEnumerable<string> headerValues = response.Headers.GetValues("AuthValue");
            // set auth value
            authorizationValue = headerValues.FirstOrDefault();
            

            // ASSERT TEST TO BE 200, OK
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        // GET ALL APPETIZERS
        [Fact, Priority(2)]
        public async Task AppetizersGetAll()
        {

/*            // Act
            var response = await _client.GetAsync("http://localhost:5002/Appetizer/Restaurant/desktopApp/all");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);*/

            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5002/Appetizer/Restaurant/desktopApp/all");
            request.Headers.Add("Authorization", "Basic " + authorizationValue);

            // Act
            var response = await _client.SendAsync(request);
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

           //var response = _client.GetAsync("http://localhost:5001/Appetizer/Restaurant/desktopApp/all");
        }

        // CREATE NEW APPETIZER WITHOUT AUTHORIZATION HEADER
        [Fact, Priority(3)]
        public async Task CreateNewAppetizerUnauthorized()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5002/Appetizer/Restaurant/create");
 
            Appetizer appetizer = new Appetizer
            {
                RestaurantId = 1,
                Name = "Awesome appetizer",
                Price = 45,
                HouseSpecial = false,
                Description = "aweesomee appetizer"
            };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(appetizer);
            var content = new StringContent(json,
            Encoding.UTF8,
            "application/x-www-form-urlencoded"
            );


            // Try to do a post without authorization header, should fail with 401 error
            HttpResponseMessage response = await _client.PostAsync("http://localhost:5002/Appetizer/Restaurant/create", content);
            
            // ASSERT TEST TO FAIL
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);

        }

        // CREATE NEW APPETIZER WITH AUTHORIZATION HEADER
        [Fact, Priority(4)]
        public async Task CreateNewAppetizerWithAuthorization()
        { 
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5002/Appetizer/Restaurant/create");
            request.Headers.Add("Authorization", "Basic " + authorizationValue);

            Appetizer appetizer = new Appetizer
            {
                RestaurantId = 1,
                Name = "Awesome appetizer",
                Price = 45,
                HouseSpecial = false,
                Description = "aweesomee appetizer"
            };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(appetizer);

            // Try to do a post
            request.Content = new StringContent(json,
                                    Encoding.UTF8,
                                    "application/json");

            var response = await _client.SendAsync(request);

            // ASSERT TEST TO BE 200
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        // UPDATE APPETIZER WITH AUTHORIZATION HEADER
        [Fact, Priority(5)]
        public async Task UpdateAppetizerWithAuthorization()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5002/Appetizer/Restaurant/edit");
            request.Headers.Add("Authorization", "Basic " + authorizationValue);
            request.Headers.Add("appetizerName", "Awesome appetizer");
            Appetizer appetizer = new Appetizer
            {
                RestaurantId = 1,
                Name = "More awesome appetizer",
                Price = 48,
                HouseSpecial = true,
                Description = "aweesomee appetizer"
            };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(appetizer);

            // Try to do a put request
            request.Content = new StringContent(json,
                                    Encoding.UTF8,
                                    "application/json");

            var response = await _client.SendAsync(request);

            // ASSERT TEST TO BE 200
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        // DELETE APPETIZER WITH AUTHORIZATION HEADER
        [Fact, Priority(6)]
        public async Task DeleteAppetizerWithAuthorization()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Delete, "http://localhost:5002/Appetizer/Restaurant/delete");
            request.Headers.Add("Authorization", "Basic " + authorizationValue);
            request.Headers.Add("appetizerName", "More awesome appetizer");


            var response = await _client.SendAsync(request);
     
            // ASSERT TEST TO BE 200
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

    }

}
