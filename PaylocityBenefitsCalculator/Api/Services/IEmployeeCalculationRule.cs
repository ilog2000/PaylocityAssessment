using Api.Models;

namespace Api.Services;

/// <summary>
/// Interface for employee calculation rules.
/// </summary>
public interface IEmployeeCalculationRule
{
    EmployeePayslip Apply(EmployeePayslip payslip);
}
