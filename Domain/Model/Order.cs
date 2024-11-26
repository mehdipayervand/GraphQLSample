namespace Domain.Model;

public class Order
{
    public string Id { get; private set; }
    public string Name { get; set; }
    public string Description { get; set;}
    public DateTime Created { get; private set; }
    public int CustomerId { get; set; }
    public OrderStatutes Statutes { get; set; }

    public Order(string id, string name,string description, DateTime created,int customerId)
    {
        Id = id;
        Name = name;
        Description = description;
        Created = created;
        CustomerId = customerId;
        Statutes = OrderStatutes.Created;
    }
}