using Domain.Model;

namespace Domain.Data;

public interface ICustomerRepository
{
    Customer GetCustomerById(int id);
    Task<Customer> GetCustomerByIdAsync(int id);
    Task<IEnumerable<Customer>> GetCustomersAsync();
}