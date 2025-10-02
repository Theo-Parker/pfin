using pfin.Model;
using pfin.Repository;
using pfin.Service;

TransactionRepository repository = new();
TransactionService transactionService = new(repository);
ReportService reportService = new(transactionService);

var transactions = repository.LoadAllTransactions();

Console.WriteLine($"{transactionService.GetBalance():C}");
Console.WriteLine();
Console.WriteLine($"{reportService.GetMonthlySummary()}");
Console.WriteLine();
Console.WriteLine($"{reportService.GetYearlySummary()}");
Console.WriteLine();