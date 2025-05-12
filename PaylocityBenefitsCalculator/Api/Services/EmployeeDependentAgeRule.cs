using System;

using Api.Extensions;
using Api.Models;

namespace Api.Services;

public class EmployeeDependentAgeRule : IEmployeeCalculationRule
{
    public EmployeePayslip Apply(EmployeePayslip payslip)
    {
        // Calculate benefits for dependents based on their age
        var benefits = 0m;
        foreach (var dependent in payslip.Employee!.Dependents)
        {
            var age = GetDependentAge(dependent.DateOfBirth);
            if (age > Constants.DependentAgeThreshold)
            {
                benefits += Constants.DependentAgeBenefit;
            }
        }

        payslip.Benefits += benefits.FromMonthlyToPaycheck(); // Converting monthly value to bi-weekly

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
