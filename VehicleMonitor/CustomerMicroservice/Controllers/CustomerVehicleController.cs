using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using CustomerMicroservice.Services;

namespace CustomerMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerVehicleController : ControllerBase
    {
        private readonly ICustomerVehicleService _customerVehicleService;
        private readonly ILogger<CustomerVehicleController> _logger;

        public CustomerVehicleController(ICustomerVehicleService customerService, ILogger<CustomerVehicleController> logger)
        {
            _customerVehicleService = customerService;
            _logger = logger; // Assign logger instance
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