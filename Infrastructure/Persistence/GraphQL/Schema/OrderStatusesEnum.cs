using GraphQL.Types;

namespace Infrastructure.Persistence.GraphQL.Schema;

public class OrderStatusesEnum : EnumerationGraphType
{
    public OrderStatusesEnum()
    {
        Name = "OrderStatuses";
        AddValue("Created", "Order was Created", 2);
        AddValue("Processing", "Order is Being processed", 4);
        AddValue("Completed", "Order is Completed", 8);
        AddValue("Cancelled", "Order was Cancelled", 16);
        AddValue("Closed", "Order was Closed", 32);
    }
}