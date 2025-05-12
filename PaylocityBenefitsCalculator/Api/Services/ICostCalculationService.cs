using Api.Models;

namespace Api.Services;

public interface ICostCalculationService
{
    /// <summary>
    /// Calculates the total costs for an employee, including salary and benefits, for a specific paycheck.
    /// </summary>
    /// <param name="employee">The employee for whom the costs are being calculated.</param>
    /// <param name="year">The year for which the paycheck is being calculated.</param>
    /// <param name="paycheckNumber">The paycheck number, ranging from 1 to 26, representing bi-weekly pay periods in a year.</param>
    /// <returns>An <see cref="EmployeePayslip"/> object containing the calculated costs and pay period details.</returns>
    EmployeePayslip CalculateEmployeeCosts(Employee employee, int year, int paycheckNumber);
}
