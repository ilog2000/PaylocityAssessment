using Api.Extensions;
using Api.Models;

namespace Api.Services;

public class EmployeeBaseRule : IEmployeeCalculationRule
{
    public EmployeePayslip Apply(EmployeePayslip payslip)
    {
        // Employee base benefit is a fixed amount per paycheck
        payslip.Benefits += Constants.EmployeeBaseBenefit.FromMonthlyToPaycheck(); // Converting monthly value to bi-weekly
        return payslip;
    }
}
