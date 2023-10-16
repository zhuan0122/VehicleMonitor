using VehicleStatusMicroservice.Models;
using VehicleStatusMicroservice.ViewModels;

namespace VehicleStatusMicroservice.Services
{
    public interface IVehicleStatusService
    {
        List<VehicleStatusViewModel> GetAllVehiclesWithStatus();

        List<Vehicle> GetVehiclesWithStatusId(int statusId);

        List<Vehicle> GetVehiclesWithStatus(string status);
    }
}