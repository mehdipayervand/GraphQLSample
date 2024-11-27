using Domain.Data;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.GraphQL.Schema;

public class OrdersMutation : ObjectGraphType
{
    public OrdersMutation()
    {
        Name = "Mutations";
        Field<OrderGraphType>(
            "createOrder",
            arguments: new QueryArguments(
                new QueryArgument[]
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>>() { Name = "Name" },
                    new QueryArgument<NonNullGraphType<StringGraphType>>() { Name = "Description" },
                    new QueryArgument<NonNullGraphType<GuidGraphType>>() { Name = "CustomerId" },
                }),
            resolve: context =>
            {
                var name = context.GetArgument<string>("Name");
                var description = context.GetArgument<string>("Description");
                var customerId = context.GetArgument<Guid>("CustomerId");

                var order = new Domain.Model.Order(name, description, customerId);

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