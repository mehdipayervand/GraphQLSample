namespace Domain.Model;

public class Order
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; private set; }
    public Guid CustomerId { get; set; }
    public OrderStatutes Statutes { get; set; }

    public Order(string name, string description, Guid customerId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Created = DateTime.UtcNow;
        CustomerId = customerId;
        Statutes = OrderStatutes.Created;
    }
}