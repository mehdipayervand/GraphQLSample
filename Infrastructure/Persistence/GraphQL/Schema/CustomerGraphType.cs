using GraphQL.Types;

namespace Infrastructure.Persistence.GraphQL.Schema;

public sealed class CustomerGraphType : ObjectGraphType<Domain.Model.Customer>
{
    public CustomerGraphType()
    {
        Field(c => c.Id);
        Field(c => c.Name);
    }
}