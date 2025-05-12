using Api.Models;

using Calc = Api.Extensions.CalculationExtensions;

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

        payslip.Benefits += Calc.MonthlyToPaycheck(benefits, Constants.PaychecksPerYear); // Converting monthly benefits to bi-weekly benefits

        return payslip;
    }
}
