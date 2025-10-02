// create dummy transaction

using pfin.Model;
using pfin.Repository;

BankAccountTransaction transaction = new()
{
    Id = 1,
    Amount = 100,
    Date = new DateOnly(2025, 10, 1),
    IsCredit = true,
    Reference = "Happy Birthday!"
};

TransactionRepository repository = new();

repository.SaveAllTransactions([transaction]);

var transactions = repository.LoadAllTransactions();

foreach (var t in transactions)
{
    Console.WriteLine(t);
}