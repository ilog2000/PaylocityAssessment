using System;

using EmployeeBenefitCostCalculation.Api.Models;

namespace EmployeeBenefitCostCalculation.Api.Services;

public class EmployeeHighSalaryRule : IEmployeeCalculationRule
{
    private const decimal SalaryThreshold = 80_000.00m;
    private const decimal HighSalaryBenefit = 0.02m; // 2% of annual salary

    public Employee Apply(Employee employee)
    {
        if (employee.Salary > SalaryThreshold)
        {
            var monthlyAmount = Math.Round(employee.Salary * HighSalaryBenefit / 12, 2); // 2% of annual salary divided by 12 months, rounded to cents
            employee.MonthlyBenefits += monthlyAmount;
        }

        return employee;
    }
}
