using System.ComponentModel.DataAnnotations;

public class CreateExpenseRequest
{
    [Required, Range(0.01, double.MaxValue)]
    public decimal Amount { get; set; }

    [Required, StringLength(200)]
    public string Description { get; set; } = null!;

    [Required]
    public string PaidBy { get; set; } = null!;

    [Required, MinLength(1)]
    public List<string> SharedWith { get; set; } = new();
}
