using System.Transactions;

namespace pfin.Repository;

public interface ITransactionRepository
{
    public void SaveAllTransactions(List<Transaction> transactions);
    public List<Transaction> LoadAllTransactions();
    public void AddTransaction();
}