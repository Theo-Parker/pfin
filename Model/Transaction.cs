namespace pfin.Model;

public abstract class Transaction
{
    public int Id { get; init; }
    public DateOnly Date { get; init; }
    public Decimal Amount { get; init; }
    public string Reference { get; init; } = "";
    public abstract decimal ApplyTo(decimal balance);
}
