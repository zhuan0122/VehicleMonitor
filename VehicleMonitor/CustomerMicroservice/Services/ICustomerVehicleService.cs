using CustomerMicroservice.Models;

namespace CustomerMicroservice.Services
{
    public interface ICustomerVehicleService
    {
        List<Customer> GetAllCustomers();

        Customer? GetCustomerById(int customerId);

        List<Vehicle> GetVehiclesForCustomerId(int customerId);
    }
}