using Domain.Model;

namespace Domain.Data;

public interface ICustomerRepository
{
    Customer GetCustomerById(Guid id);
    Task<Customer> GetCustomerByIdAsync(Guid id);
    Task<IEnumerable<Customer>> GetCustomersAsync();
}