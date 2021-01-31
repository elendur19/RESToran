using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Moq;
using RESToran.Controllers;
using RESToran.DataAccess;
using RESToran.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RESToran.IntegrationTest
{
    public class DrinkTests
    {
        private readonly HttpClient _client;

        public DrinkTests()
        {
            var server = new TestServer(new WebHostBuilder()
                                .UseStartup<Startup>());

            //var appFactory = new WebApplicationFactory<Startup>();
            _client = server.CreateClient();
        }

        [Fact]
        public async Task GetAll_ReturnsTwoProductsAsync()
        {
            Drink drink = new Drink
            {
                RestaurantId = 1,
                Name = "Awesome drink",
                Price = 45,
                HouseSpecial = false,
                AgeRestricted = true,
                Description = "aweesomee"
            };

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers.Add("emailAddress", "postman@nesto.hr");
            var mockedRepository = new Mock<PostgreSqlContext>();
            var controller = new DrinkController(mockedRepository.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };

            //ACT 
            var result = await controller.Drinks() as JsonResult; 
            var actualtResult = result.Value;

            //ASSERT
            Assert.IsType<OkObjectResult>(result);
        }

        private IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", true, true)
              .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
