using Domain.Data;
using GraphQL.Types;

namespace Infrastructure.Persistence.GraphQL.Schema;

public sealed class OrderGraphType : ObjectGraphType<Domain.Model.Order>
{

    public OrderGraphType(ICustomerRepository customerRepository)
    {
        Field(c => c.Id);
        Field(c => c.Name);
        Field(c => c.Description);
        Field<CustomerGraphType>("customer",resolve:context =>customerRepository.GetCustomerById(context.Source.CustomerId));
        Field(c => c.Created);
        Field(c => c.Statutes);
    }
}