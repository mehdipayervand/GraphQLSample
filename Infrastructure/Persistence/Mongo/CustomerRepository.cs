using Domain.Data;
using Domain.Model;
using MongoDB.Driver;

namespace Infrastructure.Persistence.Mongo;

public class CustomerRepository : ICustomerRepository
{
    private IMongoCollection<Customer> collection;

    public CustomerRepository(IMongoDatabase mongoDatabase)
    {
        collection  = mongoDatabase.GetCollection<Customer>(nameof(Customer));
    }
    
    public async Task<Customer> GetCustomerById(Guid id)
    {
        return await GetCustomerByIdAsync(id);
    }

    public async Task<Customer> GetCustomerByIdAsync(Guid id)
    {
        var customers =  await collection.Find(s=> s.Id == id).FirstOrDefaultAsync();

        return customers;
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        var filter = Builders<Customer>.Filter.Empty;

        var customers = await collection.FindSync(filter).ToListAsync();

        return customers;
    }

    public async Task InsertCustomer(Customer customer)
    {
       await collection.InsertOneAsync(customer);
    }
}