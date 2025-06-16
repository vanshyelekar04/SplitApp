namespace Application.DTOs;

public class SettlementSummary
{
    public string From { get; set; } = null!;
    public string To { get; set; } = null!;
    public decimal Amount { get; set; }
}
