using System;
using System.Collections.Generic;

using Api.Models;

namespace Api.Services;

public class CostCalculationService : ICostCalculationService
{
    private IEnumerable<IEmployeeCalculationRule> _rules;

    public CostCalculationService(IEnumerable<IEmployeeCalculationRule> rules)
    {
        _rules = rules;
    }

    public EmployeePayslip CalculateEmployeeCosts(Employee employee, int year, int paycheckNumber)
    {
        var payslip = CreateEmployeePaysleep(employee, year, paycheckNumber);
        foreach (var rule in _rules)
        {
            payslip = rule.Apply(payslip);
        }

        return payslip;
    }

    private EmployeePayslip CreateEmployeePaysleep(Employee employee, int year, int paycheckNumber)
    {
        var (startDate, endDate) = GetPayPeriod(year, paycheckNumber);
        var payslip = new EmployeePayslip
        {
            EmployeeId = employee.Id,
            // IMPORTANT: The Employee property should always be populated with a deep copy as the underlying business relies on that
            Employee = (Employee)employee.Clone(),
            EmployeeName = employee.LastName + " " + employee.FirstName,
            SalaryPay = employee.Salary / Constants.PaychecksPerYear, // Bi-weekly pay
            Benefits = 0m, // Assuming benefits are calculated in the rules
            PayPeriodStart = startDate,
            PayPeriodEnd = endDate
        };
        return payslip;
    }

    // Assuming a bi-weekly pay period, so paycheckNumber is 1-26
    private (DateTime StartDate, DateTime EndDate) GetPayPeriod(int year, int paycheckNumber)
    {
        if (paycheckNumber < 1 || paycheckNumber > Constants.PaychecksPerYear)
        {
            throw new ArgumentOutOfRangeException(nameof(paycheckNumber), $"Paycheck number must be between 1 and {Constants.PaychecksPerYear}.");
        }

        var startDate = new DateTime(year, 1, 1).AddDays((paycheckNumber - 1) * 14);
        var endDate = startDate.AddDays(13); // 14 days for bi-weekly pay period

        return (startDate, endDate);
    }
}
