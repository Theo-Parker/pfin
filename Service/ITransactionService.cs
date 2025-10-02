using pfin.Model;

namespace pfin.Service;

public interface ITransactionService
{
    public void AddTransaction(decimal amount, DateOnly date, string reference, bool IsCredit);
    public decimal GetBalance();
    public List<Transaction> GetTransactionsByMonthAndYear(Month month, int year);
    public List<Transaction> GetTransactionsByYear(int year);
    public List<Transaction> GetTransactionsByDateRange(DateOnly first, DateOnly last);
}
