using Domain.Data;
using Domain.Model;
using GraphQL.Types;

namespace Infrastructure.GraphQL.Schema;

public sealed class OrderGraphType : ObjectGraphType<Order>
{

    public OrderGraphType(ICustomerRepository customerRepository)
    {
        Field(c => c.Id);
        Field(c => c.Name);
        Field(c => c.Description);
        Field<CustomerGraphType>("customer",resolve:context =>customerRepository.GetCustomerById(context.Source.CustomerId));
        Field(c => c.Created);
    }
}