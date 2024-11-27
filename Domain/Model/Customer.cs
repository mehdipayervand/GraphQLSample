using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Model;

public class Customer
{
    [BsonId]
    public ObjectId MongoId { get; set; }

    [BsonElement("Id")]
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Customer(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}