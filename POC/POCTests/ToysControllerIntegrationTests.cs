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
        #region Variables
        private readonly ITestOutputHelper _outputHelper;
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly Random rand;
        #endregion

        public ToysControllerIntegrationTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _factory = new WebApplicationFactory<Startup>();
            rand = new();
        }

        [Fact]
        [Trait("Integration Tests","Get All Toys")]
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
        [Trait("Integration Tests", "Add New Toy")]
        public async void TestPostToyAsync()
        {
            // Arrange
            var client = _factory.CreateDefaultClient();
            var toy = new Toys() { Id = 0, Name = "My New Toy", Description = "This is a toy", CompanyId = rand.Next(4), AgeRestriction = 5, Price = rand.Next(50), ProductImageId = rand.Next(4) };

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

        [Fact]
        [Trait("Integration Tests", "Update a Toy")]
        public async void TestPutToyAsync()
        {
            // Arrange
            var client = _factory.CreateDefaultClient();
            var toy = new Toys() { Id = 5, Name = "MyToy 5 updated", Description = "This is am updated toy description", CompanyId = 4, AgeRestriction = 5, Price = 15, ProductImageId = 4 };

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(toy), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            var response = await client.PutAsync("/api/Toys/Update", httpContent);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            Assert.NotNull(responseContent);

            _outputHelper.WriteLine(JsonConvert.SerializeObject(responseContent));
        }

        [Fact]
        [Trait("Integration Tests", "Delete a Toy")]
        public async void TestDeleteToyAsync()
        {
            // Arrange
            int id = 6; //Change to a proper existin id, otherwise this will fail.
            var client = _factory.CreateDefaultClient();

            // Act
            var response = await client.DeleteAsync($"/api/Toys/Delete/{id}");

            // Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            Assert.NotNull(responseContent);

            _outputHelper.WriteLine(JsonConvert.SerializeObject(responseContent));
        }
    }
}
