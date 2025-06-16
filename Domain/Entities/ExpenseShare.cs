namespace Domain.Entities;

public class ExpenseShare
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ExpenseId { get; set; }
    public string Person { get; set; } = null!;
    public decimal ShareAmount { get; set; }
}
