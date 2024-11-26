namespace Domain.Model;

public class Customer
{
    public int Id { get; }
    public string Name { get; set; }

    public Customer(int id, string name)
    {
        Id = id;
        Name = name;
    }
}