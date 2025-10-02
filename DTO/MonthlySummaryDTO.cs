using System;
using pfin.Model;

namespace pfin.DTO;

public class MonthlySummaryDTO
{
    public Month Month { get; init; }
    public int Year { get; init; }
    public decimal TotalExpense { get; init; }
    public decimal TotalIncome { get; init; }
    public decimal NetSavings() => TotalIncome - TotalExpense;
    public TopExpenseDTO? TopExpense { get; init; }
}