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

    public override string ToString()
    {
        return $"""
        === Monthly Overview For {Month} {Year} ===
        Total Expenses: {TotalExpense:C}
        Total Income: {TotalIncome:C}
        Net Savings: {NetSavings():C}

        ===========================================

        {(TopExpense is not null ? $"The top expense for this month was: \n\n {TopExpense}" : "There were no expenses")}
        """;
    }
}