using Domain.Data;
using GraphQL.Types;

namespace Infrastructure.GraphQL.Schema;

public class OrdersQuery : ObjectGraphType<object>
{

    public OrdersQuery(IOrderRepository orderRepository)
    {
        Name = "Query";
        Field<ListGraphType<OrderGraphType>>(
            "orders",
            resolve: context => orderRepository.GetOrdersAsync()
        );
        
    }
}