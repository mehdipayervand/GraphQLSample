namespace Domain.Model;

[Flags]
public enum OrderStatutes
{
    Created = 2,
    Processing = 4,
    Completed = 8,
    Cancelled = 16,
    Closed = 32
}