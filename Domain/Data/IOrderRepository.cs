using Domain.Model;

namespace Domain.Data;

public interface IOrderRepository
{
    Task<Order> GetOrderByIdAsync(string id);
    Task<IEnumerable<Order>> GetOrdersAsync();
}