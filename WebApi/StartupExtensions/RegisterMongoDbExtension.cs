using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace WebApi.StartupExtensions;

public static class RegisterMongoDbExtension
{
    public static void ConfigureMongoDB(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration["MongoDB:ConnectionString"];
        string databaseName = configuration["MongoDB:DataBaseName"];

        var mongoClient = new MongoClient(connectionString);
        IMongoDatabase mongoDatabase = mongoClient.GetDatabase(databaseName);
        services.AddSingleton(mongoDatabase);
        
        BsonSerializer.RegisterSerializer(new GuidSerializer());
        
    }
}

public class GuidSerializer : SerializerBase<Guid>
{
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Guid value)
    {
        context.Writer.WriteString(value.ToString());
    }

    public override Guid Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        if (context.Reader.CurrentBsonType == BsonType.ObjectId)
        {
            var objectId = context.Reader.ReadObjectId();
            return new Guid(objectId.ToByteArray());
        }
        else if (context.Reader.CurrentBsonType == BsonType.String)
        {
            var stringValue = context.Reader.ReadString();
            return Guid.Parse(stringValue);
        }

        throw new InvalidOperationException($"Cannot deserialize Guid from BsonType {context.Reader.CurrentBsonType}");
    }
}
