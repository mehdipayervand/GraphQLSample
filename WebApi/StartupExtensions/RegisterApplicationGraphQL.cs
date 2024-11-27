
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.Types;
using Infrastructure.GraphQL.Schema;

namespace WebApi.StartupExtensions;

public static class RegisterApplicationGraphQL
{
    public static void ConfugureApplicationGraphQLServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ISchema, OrdersSchema>(services => new OrdersSchema(new SelfActivatingServiceProvider(services)));
        
        services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
            })
            .AddSystemTextJson();
    }
}