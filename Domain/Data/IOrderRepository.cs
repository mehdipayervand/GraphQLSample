using Domain.Model;

namespace Domain.Data;

public interface IOrderRepository
{
    Task<Order> GetOrderByIdAsync(Guid orderId);
    Task<IEnumerable<Order>> GetOrdersAsync();
    void InsertOrder(Order order);
}