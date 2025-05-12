using Api.Models;

using Calc = Api.Extensions.CalculationExtensions;

namespace Api.Services;

public class EmployeeBaseRule : IEmployeeCalculationRule
{
    public EmployeePayslip Apply(EmployeePayslip payslip)
    {
        payslip.Benefits += Calc.MonthlyToPaycheck(Constants.EmployeeBaseBenefit, Constants.PaychecksPerYear); // Converting monthly benefits to bi-weekly benefits
        return payslip;
    }
}
