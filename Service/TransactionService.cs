using System;
using pfin.Model;

namespace pfin.Service;

public class TransactionService : ITransactionService
{
    public void AddTransaction(Transaction t)
    {
        throw new NotImplementedException();
    }

    public decimal GetBalance()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetTransactionsByDateRange(DateOnly first, DateOnly last)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetTransactionsByMonth(Month month)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetTransactionsByYear(int year)
    {
        throw new NotImplementedException();
    }
}
