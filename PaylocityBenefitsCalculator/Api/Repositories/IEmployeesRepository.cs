using System.Collections.Generic;
using System.Threading.Tasks;

using EmployeeBenefitCostCalculation.Api.Models;

namespace EmployeeBenefitCostCalculation.Api.Repositories;

public interface IEmployeesRepository
{
    /// <summary>
    /// Retrieves all employees asyncronously.
    /// </summary>
    /// <returns>A collection of all employees.</returns>
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();

    /// <summary>
    /// Retrieves an employee by their unique identifier asyncronously.
    /// </summary>
    /// <param name="id">The unique identifier of the employee.</param>
    /// <returns>The employee with the specified ID, or null if not found.</returns>
    Task<Employee?> GetEmployeeByIdAsync(int id);
}
