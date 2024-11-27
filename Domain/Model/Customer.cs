
namespace Domain.Model;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Customer(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}