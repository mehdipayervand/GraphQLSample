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
    }
}