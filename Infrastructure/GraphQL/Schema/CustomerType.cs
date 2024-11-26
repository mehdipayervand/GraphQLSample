using Domain.Model;
using GraphQL.Types;

namespace Infrastructure.GraphQL.Schema;

public sealed class CustomerGraphType : ObjectGraphType<Customer>
{
    public CustomerGraphType()
    {
        Field(c => c.Id);
        Field(c => c.Name);
    }
}