using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Model;

public class Order
{
    [BsonId]
    public ObjectId MongoId { get; set; }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set;}
    public DateTime Created { get; private set; }
    public int CustomerId { get; set; }
    public OrderStatutes Statutes { get; set; }

    public Order(int id, string name,string description, DateTime created,int customerId)
    {
        Id = id;
        Name = name;
        Description = description;
        Created = created;
        CustomerId = customerId;
        Statutes = OrderStatutes.Created;
    }
}