using EmployeeBenefitCostCalculation.Api.Models;

namespace EmployeeBenefitCostCalculation.Api.Services;

public class EmployeeDependentBaseRule : IEmployeeCalculationRule
{
    private const decimal DependentBaseBenefit = 600.00m; // Base benefit for each dependent

    public EmployeePayslip Apply(EmployeePayslip payslip)
    {
        foreach (var dependent in payslip.Employee!.Dependents)
        {
            payslip.Benefits += DependentBaseBenefit;
        }

        return payslip;
    }
}
