using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using VehicleStatusMicroservice.Controllers;
using VehicleStatusMicroservice.Models;
using VehicleStatusMicroservice.Services;
using VehicleStatusMicroservice.ViewModels;
using Xunit;

namespace VehicleStatusMicroservice.Tests.ControllerTests
{
    public class VehicleStatusControllerTest
    {
        [Fact]
        public void GetVehiclesWithStatus_ValidStatus_ReturnsOkResult()
        {
            // Arrange
            var status = "Active";
            var mockService = new Mock<IVehicleStatusService>();
            mockService.Setup(service => service.GetVehiclesWithStatus(status))
                .Returns(new List<Vehicle>()); // Provide mock data as needed

            var controller = new VehicleStatusController(mockService.Object, Mock.Of<ILogger<VehicleStatusController>>());

            // Act
            var result = controller.GetVehiclesWithStatus(status);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var vehicles = Assert.IsAssignableFrom<IEnumerable<Vehicle>>(okResult.Value);
            Assert.Empty(vehicles);
        }

        [Fact]
        public void GetVehiclesWithStatusId_ValidStatusId_ReturnsOkResult()
        {
            // Arrange
            var statusId = 1;
            var mockService = new Mock<IVehicleStatusService>();
            mockService.Setup(service => service.GetVehiclesWithStatusId(statusId))
                .Returns(new List<Vehicle>()); // Provide mock data as needed

            var controller = new VehicleStatusController(mockService.Object, Mock.Of<ILogger<VehicleStatusController>>());

            // Act
            var result = controller.GetVehiclesWithStatusId(statusId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var vehicles = Assert.IsAssignableFrom<IEnumerable<Vehicle>>(okResult.Value);
            Assert.Empty(vehicles);
        }

        [Fact]
        public void GetAllVehiclesWithStatus_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var mockService = new Mock<IVehicleStatusService>();
            mockService.Setup(service => service.GetAllVehiclesWithStatus())
                .Returns(new List<VehicleStatusViewModel>()); // Provide mock data as needed

            var controller = new VehicleStatusController(mockService.Object, Mock.Of<ILogger<VehicleStatusController>>());

            // Act
            var result = controller.GetAllVehiclesWithStatus();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var vehiclesWithStatus = Assert.IsAssignableFrom<IEnumerable<VehicleStatusViewModel>>(okResult.Value);
            Assert.Empty(vehiclesWithStatus);
        }
    }
}