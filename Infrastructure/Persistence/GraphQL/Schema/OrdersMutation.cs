using Domain.Data;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.GraphQL.Schema;

public class OrdersMutation : ObjectGraphType<object>
{
    public OrdersMutation()
    {
        Name = "Mutations";
        
        Field<OrderGraphType>(
            "createOrder",
            arguments: new QueryArguments(
                // way one
                //new QueryArgument<NonNullGraphType<StringGraphType>>() { Name = "Name" },
                //new QueryArgument<NonNullGraphType<StringGraphType>>() { Name = "Description" },
                //new QueryArgument<NonNullGraphType<GuidGraphType>>() { Name = "CustomerId" },

                // way two
                new QueryArgument<NonNullGraphType<OrderCreateInput>>{Name = "order"}
                ),
            resolve: context =>
            {
                // way one
                //var name = context.GetArgument<string>("Name");
                //var description = context.GetArgument<string>("Description");
                //var customerId = context.GetArgument<Guid>("CustomerId");
                //var order = new Domain.Model.Order(name, description, customerId);

                // way two
                var orderInput = context.GetArgument<OrderCreateInput>("order");
                var order = new Domain.Model.Order(orderInput.Name, orderInput.Description,orderInput.CustomerId);

                
                var orderRepository = context.RequestServices.GetService<IOrderRepository>();
                orderRepository.InsertOrder(order).GetAwaiter().GetResult();

                return order;
            }
        );
        
        Field<CustomerGraphType>(
            "createCustomer",
            arguments: new QueryArguments(
                new QueryArgument[]
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>>() { Name = "Name" },
                }),
            resolve: context =>
            {
                var name = context.GetArgument<string>("Name");

                var customer = new Domain.Model.Customer(name);

                var customerRepository = context.RequestServices.GetService<ICustomerRepository>();
                customerRepository.InsertCustomer(customer).GetAwaiter().GetResult();;

                return customer;
            }
        );
    }
}

public class OrderCreateInput : InputObjectGraphType
{
    public OrderCreateInput()
    {
        Name = "OrderInput";
        
        Field<NonNullGraphType<StringGraphType>>(nameof(Name));
        Field<NonNullGraphType<StringGraphType>>(nameof(Description));
        Field<NonNullGraphType<StringGraphType>>(nameof(CustomerId));

    }

    public string Name { get; set; }
    public string Description { get; set; }
    public Guid CustomerId { get; set; }
}