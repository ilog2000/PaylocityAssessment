using System;

using Api.Models;

using Calc = Api.Extensions.CalculationExtensions;

namespace Api.Services;

public class EmployeeDependentAgeRule : IEmployeeCalculationRule
{
    public EmployeePayslip Apply(EmployeePayslip payslip)
    {
        var benefits = 0m;
        foreach (var dependent in payslip.Employee!.Dependents)
        {
            var age = GetDependentAge(dependent.DateOfBirth);
            if (age > Constants.DependentAgeThreshold)
            {
                benefits += Constants.DependentAgeBenefit;
            }
        }

        payslip.Benefits += Calc.MonthlyToPaycheck(benefits, Constants.PaychecksPerYear); // Converting monthly benefits to bi-weekly benefits

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
