using Api.Extensions;
using Api.Models;

namespace Api.Services;

public class EmployeeDependentBaseRule : IEmployeeCalculationRule
{
    public EmployeePayslip Apply(EmployeePayslip payslip)
    {
        var benefits = 0m;
        foreach (var dependent in payslip.Employee!.Dependents)
        {
            benefits += Constants.DependentBaseBenefit;
        }

        payslip.Benefits += benefits.FromMonthlyToPaycheck(); // Converting monthly value to bi-weekly

        return payslip;
    }
}
