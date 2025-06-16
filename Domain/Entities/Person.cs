namespace Domain.Entities;

public class Person
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Balance { get; set; } = 0m;
}
