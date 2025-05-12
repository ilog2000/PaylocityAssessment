using Api.Models;

namespace Api.Services;

public interface IEmployeeCalculationRule
{
    EmployeePayslip Apply(EmployeePayslip payslip);
}
