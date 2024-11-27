using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.GraphQL.Schema;

public class OrderSchema : global::GraphQL.Types.Schema
{
    public OrderSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Query = serviceProvider.GetRequiredService<OrdersQuery>();
        Mutation = serviceProvider.GetRequiredService<OrdersMutation>();
    }
}