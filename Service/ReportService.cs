using pfin.DTO;
using pfin.Model;

namespace pfin.Service;

public class ReportService : IReportService
{
    private ITransactionService _transactionService;


    public ReportService(ITransactionService transactionService)
    {
        this._transactionService = transactionService;
    }


    public MonthlySummaryDTO GetMonthlySummary()
    {
        DateOnly date = DateOnly.FromDateTime(DateTime.Now);
        Month currentMonth = (Month)date.Month;
        int currentYear = date.Year;

        var transactions = this._transactionService.GetTransactionsByMonthAndYear(currentMonth, currentYear);

        var expenses = GetExpenseTransactions(transactions);
        var income = GetIncomeTransactions(transactions);

        Transaction? topExpenseTransaction = expenses.MaxBy(t => t.Amount);
        TopExpenseDTO? topExpenseDTO = null;

        if (topExpenseTransaction is not null)
        {
            topExpenseDTO = new()
            {
                Description = topExpenseTransaction.Reference != "" ? topExpenseTransaction.Reference : "No",
                Amount = topExpenseTransaction.Amount,
                Date = topExpenseTransaction.Date
            };
        }

        decimal totalExpense = expenses.Sum(e => e.Amount);
        decimal totalIncome = income.Sum(i => i.Amount);

        return new MonthlySummaryDTO()
        {
            Month = currentMonth,
            TopExpense = topExpenseDTO,
            TotalExpense = totalExpense,
            TotalIncome = totalIncome,
            Year = currentYear
        };
    }



    public YearlySummaryDTO GetYearlySummary()
    {
        DateOnly date = DateOnly.FromDateTime(DateTime.Now);

        List<Transaction> transactions = this._transactionService.GetTransactionsByYear(date.Year);

        return new YearlySummaryDTO()
        {
            TopTenExpenses = getTopNExpenses(transactions, 10),
            TotalExpense = GetTotalExpense(transactions),
            TotalIncome = GetTotalIncome(transactions),
            Year = date.Year
        };



    }

    private List<Transaction> GetExpenseTransactions(List<Transaction> transactions)
    {
        List<Transaction> expenses = (from t in transactions where t is BankAccountTransaction bt && !bt.IsCredit select t).ToList();
        return expenses;
    }

    private List<Transaction> GetIncomeTransactions(List<Transaction> transactions)
    {
        List<Transaction> income = (from t in transactions where t is BankAccountTransaction bt && bt.IsCredit select t).ToList();
        return income;
    }

    private decimal GetTotalExpense(List<Transaction> transactions)
    {
        var expenses = GetExpenseTransactions(transactions);
        return expenses.Sum(t => t.Amount);
    }

    private decimal GetTotalIncome(List<Transaction> transactions)
    {
        var income = GetIncomeTransactions(transactions);
        return income.Sum(t => t.Amount);
    }

    private List<TopExpenseDTO> getTopNExpenses(List<Transaction> transactions, int numTopExpenses)
    {
        var expenseTransactions = GetExpenseTransactions(transactions);
        expenseTransactions.Sort((x, y) => x.Amount.CompareTo(y.Amount));
        expenseTransactions.Reverse();
        List<Transaction> topExpenseTransactions;
        if (expenseTransactions.Count > numTopExpenses)
        {
            topExpenseTransactions = expenseTransactions.GetRange(0, numTopExpenses);
        }
        else
        {
            topExpenseTransactions = expenseTransactions;
        }

        return topExpenseTransactions.Select(t => new TopExpenseDTO()
        {
            Amount = t.Amount,
            Date = t.Date,
            Description = t.Reference != "" ? t.Reference : "No Description"
        }).ToList();
    }
}
