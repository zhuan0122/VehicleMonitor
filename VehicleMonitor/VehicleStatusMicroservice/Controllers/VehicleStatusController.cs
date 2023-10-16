using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VehicleStatusMicroservice.Models;
using VehicleStatusMicroservice.Services;
using VehicleStatusMicroservice.ViewModels;

namespace VehicleStatusMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleStatusController : ControllerBase
    {
        private readonly IVehicleStatusService _vehicleStatusService;
        private readonly ILogger<VehicleStatusController> _logger;

        public VehicleStatusController(IVehicleStatusService vehicleStatusService, ILogger<VehicleStatusController> logger)
        {
            _vehicleStatusService = vehicleStatusService;
            _logger = logger; // Assign logger instance
        }

        [HttpGet("status/{status}")]
        [Authorize] // Requires authentication for this endpoint
        public ActionResult<IEnumerable<Vehicle>> GetVehiclesWithStatus(string status)
        {
            var vehicles = _vehicleStatusService.GetVehiclesWithStatus(status);
            return Ok(vehicles);
        }

        [HttpGet("status/{statusId:int}")]
        [Authorize] // Requires authentication for this endpoint
        public ActionResult<IEnumerable<Vehicle>> GetVehiclesWithStatusId(int statusId)
        {
            var vehicles = _vehicleStatusService.GetVehiclesWithStatusId(statusId);
            return Ok(vehicles);
        }

        [HttpGet("status")]
        [Authorize] // Requires authentication for this endpoint
        public ActionResult<IEnumerable<VehicleStatusViewModel>> GetAllVehiclesWithStatus()
        {
            var vehiclesWithStatus = _vehicleStatusService.GetAllVehiclesWithStatus();
            return Ok(vehiclesWithStatus);
        }
    }
}