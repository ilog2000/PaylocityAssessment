using System;

using Api.Models;

namespace Api.Services;

public class EmployeeHighSalaryRule : IEmployeeCalculationRule
{
    private const decimal SalaryThreshold = 80_000.00m;
    private const decimal HighSalaryBenefit = 0.02m; // 2% of annual salary

    public EmployeePayslip Apply(EmployeePayslip payslip)
    {
        if (payslip.Employee!.Salary > SalaryThreshold)
        {
            var monthlyAmount = Math.Round(payslip.Employee!.Salary * HighSalaryBenefit / 12, 2); // 2% of annual salary divided by 12 months, rounded to cents
            payslip.Benefits += monthlyAmount;
        }

        return payslip;
    }
}
