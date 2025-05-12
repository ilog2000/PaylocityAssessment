using Api.Extensions;
using Api.Models;

namespace Api.Services;

public class EmployeeHighSalaryRule : IEmployeeCalculationRule
{
    public EmployeePayslip Apply(EmployeePayslip payslip)
    {
        var benefits = 0m;
        if (payslip.Employee!.Salary > Constants.SalaryThreshold)
        {
            benefits = payslip.Employee!.Salary * Constants.HighSalaryBenefit;
        }

        payslip.Benefits += benefits.FromAnnualToPaycheck(); // 2% of annual salary divided by 26 paychecks, rounded to cents

        return payslip;
    }
}
