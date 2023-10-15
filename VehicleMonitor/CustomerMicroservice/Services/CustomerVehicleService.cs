using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CustomerMicroservice.Models;

namespace CustomerMicroService.Services
{
    public class CustomerVehicleService
    {
        private readonly VehicleMonitoringDbContext _context;

        public CustomerVehicleService(VehicleMonitoringDbContext context)
        {
            _context = context;
        }

        public List<Customer> GetAllCustomers()
        {
            var query = from customer in _context.Customers select customer;
            return query.ToList();
        }

        public Customer? GetCustomerById(int customerId)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }

        public List<Vehicle> GetVehiclesForCustomerId(int customerId)
        {
            var query = from vehicle in _context.Vehicles
                        join customer in _context.Customers
                        on vehicle.CustomerId equals customer.CustomerId
                        where customer.CustomerId == customerId
                        select vehicle;

            return query.ToList();
        }
    }
}