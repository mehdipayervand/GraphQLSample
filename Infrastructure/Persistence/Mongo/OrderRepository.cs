using Domain.Data;
using Domain.Model;
using MongoDB.Driver;

namespace Infrastructure.Persistence.Mongo;

public class OrderRepository : IOrderRepository
{
    private readonly IMongoCollection<Order> collection;

    public OrderRepository(IMongoDatabase mongoDatabase)
    {
        collection = mongoDatabase.GetCollection<Order>(nameof(Order));;
    }

    public async Task<Order> GetOrderByIdAsync(Guid id)
    {
        var filter = Builders<Order>.Filter.Eq(r => r.Id, id);
        
        var order = await collection.Find(filter).FirstOrDefaultAsync();

        return order;
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        var filter = Builders<Order>.Filter.Empty;

        var orders = await collection.FindSync(filter).ToListAsync();

        return orders;
    }

    public async Task InsertOrder(Order order)
    {
        await collection.InsertOneAsync(order);
    }

}