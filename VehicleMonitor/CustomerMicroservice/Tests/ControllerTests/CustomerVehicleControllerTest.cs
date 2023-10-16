using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CustomerMicroservice.Models;
using CustomerMicroservice.Services;
using CustomerMicroservice.Controllers;

namespace CustomerMicroservice.Tests.ControllerTests
{
    public class CustomerVehicleControllerTest
    {
        private readonly CustomerVehicleController _controller;
        private readonly Mock<ICustomerVehicleService> _mockService;
        private readonly Mock<ILogger<CustomerVehicleController>> _mockLogger;

        public CustomerVehicleControllerTest()
        {
            _mockService = new Mock<ICustomerVehicleService>();
            _mockLogger = new Mock<ILogger<CustomerVehicleController>>();
            _controller = new CustomerVehicleController(_mockService.Object, _mockLogger.Object);
        }

        [Fact]
        public void GetVehiclesForCustomer_ReturnsOkResult()
        {
            // Arrange
            int customerId = 1; // Provide customer ID as needed
            _mockService.Setup(service => service.GetVehiclesForCustomerId(customerId))
                .Returns(new List<Vehicle>()); // Provide mock data as needed

            // Act
            var result = _controller.GetVehiclesForCustomer(customerId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}