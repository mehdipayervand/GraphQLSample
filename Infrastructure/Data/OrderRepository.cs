using Domain.Data;
using Domain.Model;
using MongoDB.Driver;

namespace Infrastructure.Data;

public class OrderRepository:IOrderRepository 
{
    private readonly IMongoDatabase mongoDatabase;

    public OrderRepository(IMongoDatabase mongoDatabase)
    {
        this.mongoDatabase = mongoDatabase;
    }
    
    
    public Task<Order> GetOrderByIdAsync(string id)
    {
        var collection = getCollection();

        var order =  collection.Find(s=> s.Id == id).FirstOrDefault();
        
        return Task.FromResult(order);
    }

    public Task<IEnumerable<Order>> GetOrdersAsync()
    {
        var collection = getCollection();
        
        var filter = Builders<Order>.Filter.Empty;

        var orders =  collection.FindSync(filter).ToEnumerable();
        
        return Task.FromResult(orders);
    }
    
    
    private IMongoCollection<Order> getCollection()
    {
        return mongoDatabase.GetCollection<Order>(nameof(Order));
    }
}