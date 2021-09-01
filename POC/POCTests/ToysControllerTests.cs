using Microsoft.AspNetCore.Mvc;
using Moq;
using POC.Controllers;
using POC_Models.Models;
using POC_Models.ViewModels;
using POC_Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace POCTests
{
    public class ToysControllerTests
    {
        private readonly Mock<IToysService> _toysServiceStub = new();
        private readonly Random rand = new();

        [Fact]
        public async Task GetToysAsync_WithNoItems_ReturnsNull()
        {
            // Arrange
            _toysServiceStub.Setup(service => service.GetToysAsync())
                .ReturnsAsync(null as ToysViewModel[]);
            // Act
            var controller = new ToysController(_toysServiceStub.Object);
            var result = await controller.Toys();

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetToysAsync_ReturnsAllItems()
        {
            // Arrange
            var expectedItems = new[] { GenerateRandomObjectForList(), GenerateRandomObjectForList(), GenerateRandomObjectForList() };

            _toysServiceStub.Setup(service => service.GetToysAsync())
                .ReturnsAsync(expectedItems);
            // Act
            var controller = new ToysController(_toysServiceStub.Object);
            var result = await controller.Toys();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateToyAsync_WithNInvalidModel_ReturnsBadRequest()
        {
            // Arrange
            var invalidModel = GenerateBadRandomObjectWithNoId();

            _toysServiceStub.Setup(service => service.UpdateToyAsync(invalidModel))
                .ReturnsAsync(false);

            // Act
            var controller = new ToysController(_toysServiceStub.Object);
            controller.ModelState.AddModelError("Error", "Invalid Model");
            var result = await controller.Update(invalidModel);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task UpdateToyAsync_WithNoId_ReturnsNotFound()
        {
            // Arrange
            var invalidModel = GenerateBadRandomObjectWithNoId();

            _toysServiceStub.Setup(service => service.UpdateToyAsync(invalidModel))
                .ReturnsAsync(false);

            // Act
            var controller = new ToysController(_toysServiceStub.Object);
            var result = await controller.Update(invalidModel);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task UpdateToyAsync_WithValidModelAndId_ReturnsOk()
        {
            // Arrange
            var validModel = GenerateRandomObjectForUpdate();

            _toysServiceStub.Setup(service => service.UpdateToyAsync(validModel))
                .ReturnsAsync(true);

            // Act
            var controller = new ToysController(_toysServiceStub.Object);
            var result = await controller.Update(validModel);

            // Result
            Assert.IsType<OkObjectResult>(result);
        }

        #region Helper functions
        private ToysViewModel GenerateRandomObjectForList()
        {
            return new()
            {
                Id = rand.Next(100),
                Name = Guid.NewGuid().ToString(),
                Age = rand.Next(10),
                Company = Guid.NewGuid().ToString(),
                Price = Convert.ToDecimal(rand.NextDouble())
            };
        }

        private Toys GenerateRandomObjectForUpdate()
        {
            return new()
            {
                Id = rand.Next(100),
                Name = Guid.NewGuid().ToString(),
                AgeRestriction = rand.Next(10),
                Description = Guid.NewGuid().ToString(),
                Company = Guid.NewGuid().ToString(),
                Price = Convert.ToDecimal(rand.NextDouble()),
                ProductImage = Guid.NewGuid().ToString()
            };
        }

        private Toys GenerateBadRandomObjectWithNoId()
        {
            return new()
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                AgeRestriction = rand.Next(10),
                Company = Guid.NewGuid().ToString(),
                Price = Convert.ToDecimal(rand.NextDouble())
            };
        }
        #endregion
    }
}
