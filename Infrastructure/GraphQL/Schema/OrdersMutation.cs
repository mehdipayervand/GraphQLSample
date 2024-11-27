using Domain.Data;
using Domain.Model;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.GraphQL.Schema;

public class OrdersMutation : ObjectGraphType
{
    public OrdersMutation()
    {
        Name = "CreateOrder";
        Field<OrderGraphType>(
            "createOrder",
            arguments: new QueryArguments(
                new QueryArgument[]
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>>(){Name = "Name"},
                    new QueryArgument<NonNullGraphType<StringGraphType>>(){Name = "Description"},
                    new QueryArgument<NonNullGraphType<GuidGraphType>>(){Name = "CustomerId"},
                }),
            resolve: context =>
            {
                var name = context.GetArgument<string>("Name");
                var description = context.GetArgument<string>("Description");
                var customerId = context.GetArgument<Guid>("CustomerId");

                var order = new Order(name, description, customerId);

                var orderRepository = context.RequestServices.GetService<IOrderRepository>();
                orderRepository.InsertOrder(order);
                
                return order;
            }
        );
    }
}