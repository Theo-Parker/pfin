using System;
using pfin.Model;
using pfin.Repository;

namespace pfin.Service;

public class TransactionService : ITransactionService
{
    private List<Transaction> _transactions = [];
    private ITransactionRepository _repository;
    public TransactionService(ITransactionRepository repository)
    {
        this._repository = repository;
        this._transactions = repository.LoadAllTransactions();
    }
    public void AddTransaction(decimal amount, DateOnly date, string reference, bool IsCredit = true)
    {
        int newId = this._transactions.LastOrDefault()?.Id ?? 1;
        BankAccountTransaction transaction = new() { Id = newId, Reference = reference, Amount = amount, Date = date, IsCredit = IsCredit };
        this._transactions.Add(transaction);
        this._repository.SaveAllTransactions(_transactions);
    }

    // TODO: this is a bad way to do it, should probably keep track of balance separately
    public decimal GetBalance()
    {
        decimal totalIncome = (
            from t in _transactions
            where t is BankAccountTransaction bt && bt.IsCredit
            select t.Amount
        ).Sum();

        decimal totalExpense = (
            from t in _transactions
            where t is BankAccountTransaction bt && !bt.IsCredit
            select t.Amount
        ).Sum();

        return totalIncome - totalExpense;
    }

    public List<Transaction> GetTransactionsByDateRange(DateOnly first, DateOnly last)
    {
        return (
            from t in _transactions
            where t.Date >= first && t.Date <= last
            select t
        ).ToList();
    }

    public List<Transaction> GetTransactionsByMonth(Month month)
    {
        return (
            from t in _transactions
            where t.Date.Month == (int) month
            select t
        ).ToList();
    }

    public List<Transaction> GetTransactionsByYear(int year)
    {
        return (
            from t in _transactions
            where t.Date.Year == year
            select t
        ).ToList();
    }
}
