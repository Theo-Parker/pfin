namespace pfin.DTO;

public class TopExpenseDTO
{
    public string Description { get; init; } = "No Description";
    public decimal Amount { get; init; }
    public DateOnly Date { get; init; }
}
