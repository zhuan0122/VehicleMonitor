using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;
using VehicleStatusMicroservice.Models;
using VehicleStatusMicroservice.Services;
using VehicleStatusMicroservice.ViewModels;

namespace VehicleStatusMicroservice.Tests.ServiceTests
{
    public class VehicleStatusServiceTests
    {
        [Fact]
        public void GetAllVehiclesWithStatus_ShouldReturnListOfVehicleStatusViewModel()
        {
            // Arrange
            var vehicles = new List<Vehicle>
            {
                new Vehicle { VehicleId = 1, RegNumber = "Reg1" },
                new Vehicle { VehicleId = 2, RegNumber = "Reg2" }
            };

            var vehicleStatuses = new List<Vehiclestatus>
            {
                new Vehiclestatus { VehicleId = 1, StatusId = 1, Status = "Active" },
                new Vehiclestatus { VehicleId = 2, StatusId = 2, Status = "Inactive" }
            };

            var mockDbContext = new Mock<VehicleStatusDbContext>();
            mockDbContext.Setup(db => db.Vehicles).Returns(DbSetMock.GetDbSetMock(vehicles));
            mockDbContext.Setup(db => db.Vehiclestatuses).Returns(DbSetMock.GetDbSetMock(vehicleStatuses));

            var vehicleStatusService = new VehicleStatusService(mockDbContext.Object);

            // Act
            var result = vehicleStatusService.GetAllVehiclesWithStatus();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(vehicles.Count, result.Count);

            // Verify that the returned list contains instances of VehicleStatusViewModel
            Assert.All(result, item => Assert.IsType<VehicleStatusViewModel>(item));
        }

        [Fact]
        public void GetVehiclesWithStatus_ShouldReturnListOfVehiclesOrReturnEmpty()
        {
            // Arrange
            var vehicles = new List<Vehicle>
            {
                new Vehicle { VehicleId = 1, RegNumber = "Reg1" },
                new Vehicle { VehicleId = 2, RegNumber = "Reg2" }
            };

            var vehicleStatuses = new List<Vehiclestatus>
            {
                new Vehiclestatus { VehicleId = 1, StatusId = 1, Status = "Active" },
                new Vehiclestatus { VehicleId = 2, StatusId = 2, Status = "Inactive" }
            };

            var mockDbContext = new Mock<VehicleStatusDbContext>();
            mockDbContext.Setup(db => db.Vehicles).Returns(DbSetMock.GetDbSetMock(vehicles));
            mockDbContext.Setup(db => db.Vehiclestatuses).Returns(DbSetMock.GetDbSetMock(vehicleStatuses));

            var vehicleStatusService = new VehicleStatusService(mockDbContext.Object);

            // Act
            var status = "Active";
            var nonExistedStatus = "connected";
            var result = vehicleStatusService.GetVehiclesWithStatus(status);
            var emptyResult = vehicleStatusService.GetVehiclesWithStatus(nonExistedStatus);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result); // Assuming only one vehicle has status "Active"
            Assert.Equal(1, result[0].VehicleId);

            Assert.Empty(emptyResult);
        }

        [Fact]
        public void GetVehiclesWithStatusId_ShouldReturnListOfVehiclesOrReturnEmpty()
        {
            // Arrange
            var vehicles = new List<Vehicle>
            {
                new Vehicle { VehicleId = 1, RegNumber = "Reg1" },
                new Vehicle { VehicleId = 2, RegNumber = "Reg2" }
            };

            var vehicleStatuses = new List<Vehiclestatus>
            {
                new Vehiclestatus { VehicleId = 1, StatusId = 1, Status = "Active" },
                new Vehiclestatus { VehicleId = 2, StatusId = 2, Status = "Inactive" }
            };

            var mockDbContext = new Mock<VehicleStatusDbContext>();
            mockDbContext.Setup(db => db.Vehicles).Returns(DbSetMock.GetDbSetMock(vehicles));
            mockDbContext.Setup(db => db.Vehiclestatuses).Returns(DbSetMock.GetDbSetMock(vehicleStatuses));

            var vehicleStatusService = new VehicleStatusService(mockDbContext.Object);

            // Act
            var statusId = 1;
            var nonEixstedStatusId = 3;
            var result = vehicleStatusService.GetVehiclesWithStatusId(statusId);
            var emptyResult = vehicleStatusService.GetVehiclesWithStatusId(nonEixstedStatusId);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result); // Assuming only one vehicle has statusId 1
            Assert.Equal(1, result[0].VehicleId);

            Assert.Empty(emptyResult);
        }
    }
}