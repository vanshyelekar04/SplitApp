namespace Domain.Entities;

public class Expense
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Description { get; set; } = null!;
    public decimal Amount { get; set; }
    public string PaidBy { get; set; } = null!;
    public List<ExpenseShare> Shares { get; set; } = new();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
