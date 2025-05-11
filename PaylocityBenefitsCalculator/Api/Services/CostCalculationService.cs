using System;
using System.Collections.Generic;

using EmployeeBenefitCostCalculation.Api.Models;

namespace EmployeeBenefitCostCalculation.Api.Services;

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

        return AdjustPayslipBenefits(payslip);
    }

    private EmployeePayslip AdjustPayslipBenefits(EmployeePayslip payslip)
    {
        // Adjust the benefits to be half of the calculated amount as all rules calculate monthly values,
        // but we are calculating bi-weekly payslips
        payslip.Benefits = Math.Round(payslip.Benefits / 2, 2);
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
            SalaryPay = employee.Salary / 2, // Assuming bi-weekly pay
            Benefits = 0m, // Assuming benefits are calculated in the rules
            PayPeriodStart = startDate,
            PayPeriodEnd = endDate
        };
        return payslip;
    }

    // Assuming a bi-weekly pay period that starts on the 1st or 15th of the month
    private (DateTime StartDate, DateTime EndDate) GetPayPeriod(int year, int paycheckNumber)
    {
        var month = paycheckNumber / 2 + 1;
        var isFirstHalfOfMonth = paycheckNumber % 2 == 1;
        var startDate = new DateTime(year, month, isFirstHalfOfMonth ? 1 : 15);
        var endDate = isFirstHalfOfMonth
            ? startDate.AddDays(13) // 1st to 14th
            : new DateTime(startDate.Year, startDate.Month, DateTime.DaysInMonth(startDate.Year, startDate.Month));

        return (startDate, endDate);
    }
}
