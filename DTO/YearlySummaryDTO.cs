using System;

namespace pfin.DTO;

public class YearlySummaryDTO
{
    public int Year { get; init; }
    public decimal TotalIncome { get; init; }
    public decimal TotalExpense { get; init; }
    public decimal NetSavings() => TotalIncome - TotalExpense;
    public List<TopExpenseDTO> TopTenExpenses { get; init; } = [];
}
