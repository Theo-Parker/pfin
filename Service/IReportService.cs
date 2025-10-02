using System;
using pfin.DTO;

namespace pfin.Service;

public interface IReportService
{
    public MonthlySummaryDTO GetMonthlySummary();
    public YearlySummaryDTO GetYearlySummary();
}
