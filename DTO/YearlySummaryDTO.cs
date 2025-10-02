using System;

namespace pfin.DTO;

public class YearlySummaryDTO
{
    public int Year { get; init; }
    public decimal TotalIncome { get; init; }
    public decimal TotalExpense { get; init; }
    public decimal NetSavings() => TotalIncome - TotalExpense;
    public List<TopExpenseDTO> TopTenExpenses { get; init; } = [];
    public override string ToString()
    {
        return $"""
        === Yearly Overview For {Year} ===
        Total Expenses: {TotalExpense:C}
        Total Income: {TotalIncome:C}
        Net Savings: {NetSavings():C}

        ===========================================

        {(TopTenExpenses is not null ? $"The top ten expenses for this year were: \n\n{string.Join("\n", TopTenExpenses.Select((t, index) => $"{(index + 1), 2}. {t.Date} | {t.Amount:C} | {(t.Description is not "" ? t.Description : "No Description")}").ToList())}" : "There were no expenses")}
        """;
    }
}
