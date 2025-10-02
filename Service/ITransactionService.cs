using pfin.Model;

namespace pfin.Service;

public interface ITransactionService
{
    public void AddTransaction(Transaction t);
    public decimal GetBalance();
    public IEnumerable<Transaction> GetTransactionsByMonth(Month month);
    public IEnumerable<Transaction> GetTransactionsByYear(int year);
    public IEnumerable<Transaction> GetTransactionsByDateRange(DateOnly first, DateOnly last);
}
