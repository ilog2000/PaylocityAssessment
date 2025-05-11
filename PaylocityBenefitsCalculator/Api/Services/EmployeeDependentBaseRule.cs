using EmployeeBenefitCostCalculation.Api.Models;

namespace EmployeeBenefitCostCalculation.Api.Services;

public class EmployeeDependentBaseRule : IEmployeeCalculationRule
{
    private const decimal DependentBaseBenefit = 600.00m; // Base benefit for each dependent

    public Employee Apply(Employee employee)
    {
        foreach (var dependent in employee.Dependents)
        {
            employee.MonthlyBenefits += DependentBaseBenefit;
        }

        return employee;
    }
}
