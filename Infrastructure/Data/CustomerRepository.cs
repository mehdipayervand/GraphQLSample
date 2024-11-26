using Domain.Data;
using Domain.Model;
using MongoDB.Driver;

namespace Infrastructure.Data;

public class CustomerRepository : ICustomerRepository
{
    private readonly IMongoDatabase mongoDatabase;

    public CustomerRepository(IMongoDatabase mongoDatabase)
    {
        this.mongoDatabase = mongoDatabase;
    }
    
    public Customer GetCustomerById(int id)
    {
        return GetCustomerByIdAsync(id).Result;
    }

    public Task<Customer> GetCustomerByIdAsync(int id)
    {
        var collection = getCollection();

        var customers =  collection.Find(s=> s.Id == id).FirstOrDefault();
        
        return Task.FromResult(customers);
    }

    public Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        var collection = getCollection();
        
        var filter = Builders<Customer>.Filter.Empty;

        var customers =  collection.FindSync(filter).ToEnumerable();
        
        return Task.FromResult(customers);
    }
    
    
    private IMongoCollection<Customer> getCollection()
    {
        return mongoDatabase.GetCollection<Customer>(nameof(Customer));
    }
}