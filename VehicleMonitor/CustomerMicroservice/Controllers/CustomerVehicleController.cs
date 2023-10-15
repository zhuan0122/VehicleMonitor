using Microsoft.AspNetCore.Mvc;
using CustomerMicroService.Services;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace CustomerMicroService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerVehicleController : ControllerBase
    {
        private readonly CustomerVehicleService _customerVehicleService;
        private readonly ILogger<CustomerVehicleController> _logger;

        public CustomerVehicleController(CustomerVehicleService customerService, ILogger<CustomerVehicleController> logger)
        {
            _customerVehicleService = customerService;
            _logger = logger; // Assign logger instance
        }

        [HttpGet]
        [Authorize] // Requires authentication for this endpoint
        public IActionResult GetAllCustomers()
        {
            _logger.LogInformation("Received request: GET /api/customers");
            var customers = _customerVehicleService.GetAllCustomers();
            _logger.LogInformation($"Sending response: {JsonConvert.SerializeObject(customers)}");
            return Ok(customers);
        }

        [HttpGet("{customerId}/vehicles")]
        [Authorize] // Requires authentication for this endpoint
        public IActionResult GetVehiclesForCustomer(int customerId)
        {
            var vehicles = _customerVehicleService.GetVehiclesForCustomerId(customerId);
            return Ok(vehicles);
        }
    }
}