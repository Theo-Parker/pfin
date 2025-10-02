using pfin.Model;

namespace pfin.Repository;

public interface ITransactionRepository
{
    public void SaveAllTransactions(List<Transaction> transactions);
    public List<Transaction> LoadAllTransactions();
}