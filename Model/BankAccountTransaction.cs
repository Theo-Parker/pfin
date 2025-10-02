namespace pfin.Model;

public sealed class BankAccountTransaction : Transaction
{
    public bool IsCredit { get; init; }
    public override decimal ApplyTo(decimal balance) => this.IsCredit ? balance + this.Amount : balance - this.Amount;
    public override string ToString()
    {
        return $"BankAccountTransaction - Reference: {(Reference is not "" ? Reference : "No Reference")}, Amount: {(IsCredit ? $"+{Amount:C}" : $"-{Amount:C}")}";
    }
}