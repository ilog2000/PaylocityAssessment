using EmployeeBenefitCostCalculation.Api.Models;

namespace EmployeeBenefitCostCalculation.Api.Services;

public class EmployeeBaseRule : IEmployeeCalculationRule
{
    private const decimal EmployeeBaseBenefit = 1000.00m; // Base benefit for each employee

    public Employee Apply(Employee employee)
    {
        employee.MonthlyBenefits += EmployeeBaseBenefit;
        return employee;
    }
}
