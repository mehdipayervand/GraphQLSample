using Domain.Data;
using GraphQL;
using GraphQL.Types;

namespace Infrastructure.Persistence.GraphQL.Schema;

public class OrdersQuery : ObjectGraphType<object>
{
    public OrdersQuery(IOrderRepository orderRepository, ICustomerRepository customerRepository)
    {
        Name = "Queries";
        
        Field<ListGraphType<OrderGraphType>>(
            "orders",
            resolve: context => orderRepository.GetOrdersAsync()
        );
        
        Field<OrderGraphType>(
            "orderById",
            arguments: new QueryArguments(new QueryArgument<GuidGraphType>() { Name = "Id" }),
            resolve: context => orderRepository.GetOrderByIdAsync(context.GetArgument<Guid>("id"))
        );
        
        Field<ListGraphType<OrderGraphType>>(
            "customers",
            resolve: context => customerRepository.GetCustomersAsync()
        );
        
        Field<OrderGraphType>(
            "customerById",
            arguments: new QueryArguments(new QueryArgument<GuidGraphType>() { Name = "Id" }),
            resolve: context => customerRepository.GetCustomerById(context.GetArgument<Guid>("id"))
        );
        
    }
}