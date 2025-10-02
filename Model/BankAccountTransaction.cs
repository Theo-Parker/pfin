namespace pfin.Model;

public sealed class BankAccountTransaction : Transaction
{
    public bool IsCredit { get; init; }
    public override decimal ApplyTo(decimal balance) => this.IsCredit ? balance + this.Amount : balance - this.Amount;
}