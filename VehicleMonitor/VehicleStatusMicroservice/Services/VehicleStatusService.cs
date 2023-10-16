using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VehicleStatusMicroservice.Models;
using VehicleStatusMicroservice.Services;
using VehicleStatusMicroservice.ViewModels;

namespace VehicleStatusMicroservice.Services
{
    public class VehicleStatusService : IVehicleStatusService
    {
        private readonly VehicleStatusDbContext _context;

        public VehicleStatusService(VehicleStatusDbContext context)
        {
            _context = context;
        }

        public List<VehicleStatusViewModel> GetAllVehiclesWithStatus()
        {
            if (_context.Vehicles == null || _context.Vehiclestatuses == null)
            {
                return new List<VehicleStatusViewModel>();
            }

            var query = from vehicle in _context.Vehicles
                        join vehicleStatus in _context.Vehiclestatuses
                        on vehicle.VehicleId equals vehicleStatus.VehicleId
                        select new VehicleStatusViewModel
                        {
                            VehicleId = vehicle.VehicleId,
                            RegNumber = vehicle.RegNumber,
                            StatusId = vehicleStatus.StatusId,
                            Status = vehicleStatus.Status
                        };

            return query.ToList();
        }

        public List<Vehicle> GetVehiclesWithStatus(string status)
        {
            if (_context.Vehicles == null || _context.Vehiclestatuses == null)
            {
                return new List<Vehicle>();
            }

            var query = from vehicle in _context.Vehicles
                        join vehicleStatus in _context.Vehiclestatuses
                        on vehicle.VehicleId equals vehicleStatus.VehicleId
                        where (vehicleStatus.Status != null && vehicleStatus.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
                        select vehicle;

            return query.ToList();
        }

        public List<Vehicle> GetVehiclesWithStatusId(int statusId)
        {
            if (_context.Vehicles == null || _context.Vehiclestatuses == null)
            {
                return new List<Vehicle>();
            }

            var query = from vehicle in _context.Vehicles
                        join vehicleStatus in _context.Vehiclestatuses
                        on vehicle.VehicleId equals vehicleStatus.VehicleId
                        where vehicleStatus.StatusId == statusId
                        select vehicle;

            return query.ToList();
        }
    }
}