using System;

using EmployeeBenefitCostCalculation.Api.Models;

namespace EmployeeBenefitCostCalculation.Api.Services;

public class EmployeeDependentAgeRule : IEmployeeCalculationRule
{
    private const int DependentAgeThreshold = 50;
    private const decimal DependentAgeBenefit = 200.00m;

    public EmployeePayslip Apply(EmployeePayslip payslip)
    {
        foreach (var dependent in payslip.Employee!.Dependents)
        {
            var age = GetDependentAge(dependent.DateOfBirth);
            if (age > DependentAgeThreshold)
            {
                payslip.Benefits += DependentAgeBenefit;
            }
        }

        return payslip;
    }

    private int GetDependentAge(DateTime dateOfBirth)
    {
        var today = DateTime.Today;
        var age = today.Year - dateOfBirth.Year;
        if (dateOfBirth > today.AddYears(-age))
        {
            age--;
        }
        return age;
    }
}
