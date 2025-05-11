using EmployeeBenefitCostCalculation.Api.Models;

namespace EmployeeBenefitCostCalculation.Api.Services;

public interface IEmployeeCalculationRule
{
    EmployeePayslip Apply(EmployeePayslip payslip);
}
