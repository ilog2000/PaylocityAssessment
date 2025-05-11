using EmployeeBenefitCostCalculation.Api.Models;

namespace EmployeeBenefitCostCalculation.Api.Services;

public class EmployeeBaseRule : IEmployeeCalculationRule
{
    private const decimal EmployeeBaseBenefit = 1000.00m; // Base benefit for each employee

    public EmployeePayslip Apply(EmployeePayslip payslip)
    {
        payslip.Benefits += EmployeeBaseBenefit;
        return payslip;
    }
}
