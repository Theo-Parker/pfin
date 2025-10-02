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
Console.WriteLine("\n\n\n\n");

bool running = true;
do
{
    Console.WriteLine("""
    What would you like to do?
    1. Make a transaction
    2. See your balance
    3. See your monthly transaction summary
    4. See your yearly transaction summary
    5. Exit
    """);

    string input = Console.ReadLine();
    bool valid = int.TryParse(input, System.Globalization.CultureInfo.InvariantCulture, out int result);
    if (!valid) { continue; }
    switch (result)
    {
        case 1:
            MakeTransaction();
            break;
        default:
            break;
    }
} while (running);

void MakeTransaction()
{
    bool makingTransaction = true;
    do
    {
        Console.WriteLine("Make a transaction");
        makingTransaction = false;
    } while (makingTransaction);
};