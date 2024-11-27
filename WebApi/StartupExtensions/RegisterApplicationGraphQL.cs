
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.Types;
using Infrastructure.Persistence.GraphQL.Schema;

namespace WebApi.StartupExtensions;

public static class RegisterApplicationGraphQL
{
    public static void ConfugureApplicationGraphQLServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ISchema, OrderSchema>(services => new OrderSchema(new SelfActivatingServiceProvider(services)));
        
        services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
            })
            .AddSystemTextJson();
    }
}