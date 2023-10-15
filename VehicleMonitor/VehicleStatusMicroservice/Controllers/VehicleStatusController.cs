using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VehicleStatusMicroservice.Models;
using VehicleStatusMicroService.Services;
using VehicleStatusMicroService.ViewModels;

namespace VehicleStatusMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleStatusController : ControllerBase
    {
        private readonly VehicleStatusService _vehicleStatusService;
        private readonly ILogger<VehicleStatusController> _logger;

        public VehicleStatusController(VehicleStatusService vehicleStatusService, ILogger<VehicleStatusController> logger)
        {
            _vehicleStatusService = vehicleStatusService;
            _logger = logger; // Assign logger instance
        }

        [HttpGet]
        public IActionResult GetAllvehicles()
        {
            _logger.LogInformation("Received request: GET /api/customers");
            var vehciles = _vehicleStatusService.GetAllVehicles();
            _logger.LogInformation($"Sending response: {JsonConvert.SerializeObject(vehciles)}");
            return Ok(vehciles);
        }

        [HttpGet("status/{status}")]
        public ActionResult<IEnumerable<Vehicle>> GetVehiclesWithStatus(string status)
        {
            var vehicles = _vehicleStatusService.GetVehiclesWithStatus(status);
            return Ok(vehicles);
        }

        [HttpGet("status/{statusId:int}")]
        public ActionResult<IEnumerable<Vehicle>> GetVehiclesWithStatusId(int statusId)
        {
            var vehicles = _vehicleStatusService.GetVehiclesWithStatusId(statusId);
            return Ok(vehicles);
        }

        [HttpGet("status")]
        public ActionResult<IEnumerable<VehicleStatusViewModel>> GetAllVehiclesWithStatus()
        {
            var vehiclesWithStatus = _vehicleStatusService.GetAllVehiclesWithStatus();
            return Ok(vehiclesWithStatus);
        }
    }
}