using Xunit;
using Moq;
using CustomerMicroservice.Models;
using CustomerMicroservice.Services;
using System.Collections.Generic;
using CustomerMicroservice.Tests.ServiceTests;

namespace CustomerMicroservice.Tests.ServiceTests
{
    public class CustomerVehicleServiceTest
    {
        private readonly Mock<VehicleMonitoringDbContext> _dbContext;
        private readonly ICustomerVehicleService _customerVehicleService;

        public CustomerVehicleServiceTest()
        {
            _dbContext = new Mock<VehicleMonitoringDbContext>();
            _customerVehicleService = new CustomerVehicleService(_dbContext.Object);
        }

        [Fact]
        public void GetAllCustomers_ShouldReturnListOfCustomers()
        {
            // Arrange
            var customers = new List<Customer>
                {
                    new Customer { CustomerId = 1, Name = "Customer 1", Address = "Address 1" },
                    new Customer { CustomerId = 2, Name = "Customer 2", Address = "Address 2" }
                };

            _dbContext.Setup(x => x.Customers).Returns(DbSetMock.GetDbSetMock(customers));

            // Act
            var result = _customerVehicleService.GetAllCustomers();

            // Assert
            Assert.Equal(customers, result);
        }

        [Fact]
        public void GetCustomerById_ShouldReturnCustomerOrNull()
        {
            // Arrange
            var customers = new List<Customer>
        {
            new Customer { CustomerId = 1, Name = "Customer 1", Address = "Address 1" },
            new Customer { CustomerId = 2, Name = "Customer 2", Address = "Address 2" }
        };

            _dbContext.Setup(x => x.Customers).Returns(DbSetMock.GetDbSetMock(customers));
            var existingCustomerId = 1;
            var nonExistingCustomerId = 3;

            // Act
            var result = _customerVehicleService.GetCustomerById(existingCustomerId);
            var nullResult = _customerVehicleService.GetCustomerById(nonExistingCustomerId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customers.First(c => c.CustomerId == existingCustomerId), result);
            Assert.Null(nullResult);
        }

        [Fact]
        public void GetVehiclesForCustomerId_ShouldReturnListOfVehiclesOrEmpty()
        {
            // Arrange
            var vehicles = new List<Vehicle>
            {
                new Vehicle { VehicleId = 1, CustomerId = 1, Vin = "VIN1", RegNumber = "Reg1" },
                new Vehicle { VehicleId = 2, CustomerId = 1, Vin = "VIN2", RegNumber = "Reg2" }
            };

            var customers = new List<Customer>
            {
                new Customer { CustomerId = 1, Name = "Customer 1", Address = "Address 1" },
                new Customer { CustomerId = 2, Name = "Customer 2", Address = "Address 2" }
            };

            var mockDbContext = new Mock<VehicleMonitoringDbContext>();
            mockDbContext.Setup(db => db.Customers).Returns(DbSetMock.GetDbSetMock(customers));
            mockDbContext.Setup(db => db.Vehicles).Returns(DbSetMock.GetDbSetMock(vehicles));

            var customerVehicleService = new CustomerVehicleService(mockDbContext.Object);

            // Act
            var existingCustomerId = 1;
            var nonExistingCustomerId = 3;
            var result = customerVehicleService.GetVehiclesForCustomerId(existingCustomerId);
            var emptyResult = _customerVehicleService.GetVehiclesForCustomerId(nonExistingCustomerId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(vehicles, result);
            Assert.Empty(emptyResult);
        }
    }
}