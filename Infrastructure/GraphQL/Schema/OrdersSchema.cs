using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.GraphQL.Schema;

public class OrdersSchema : global::GraphQL.Types.Schema
{
    public OrdersSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Query = serviceProvider.GetRequiredService<OrdersQuery>();
        Mutation = serviceProvider.GetRequiredService<OrdersMutation>();
    }
}