using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using POC;
using POC_Models.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace POCTests
{
    public class ToysControllerIntegrationTests
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly WebApplicationFactory<Startup> _factory;

        public ToysControllerIntegrationTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _factory = new WebApplicationFactory<Startup>();
        }

        [Fact]
        public async void TestGetToysAsync()
        {
            // Arrange
            var client = _factory.CreateDefaultClient();

            // Act
            var response = await client.GetAsync("/api/Toys/ToysList");

            // Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            Assert.NotNull(responseContent);

            _outputHelper.WriteLine(JsonConvert.SerializeObject(responseContent));
        }

        [Fact]
        public async void TestPostToyAsync()
        {
            // Arrange
            var client = _factory.CreateDefaultClient();
            var toy = new Toys() { Id = 0, Name = "MyToy 5", Description = "This is a toy", CompanyId = 4, AgeRestriction = 5, Price = 15, ProductImageId = 4 };

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(toy), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            var response = await client.PostAsync("/api/Toys/Save", httpContent);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            Assert.NotNull(responseContent);

            _outputHelper.WriteLine(JsonConvert.SerializeObject(responseContent));
        }
    }
}
