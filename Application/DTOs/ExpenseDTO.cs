namespace Application.DTOs;

public class ExpenseDTO
{
    public Guid Id { get; set; }
    public string Description { get; set; } = null!;
    public decimal Amount { get; set; }
    public string PaidBy { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public List<ExpenseShareDTO> Shares { get; set; } = new();
}

public class ExpenseShareDTO
{
    public string Person { get; set; } = null!;
    public decimal ShareAmount { get; set; }
}
