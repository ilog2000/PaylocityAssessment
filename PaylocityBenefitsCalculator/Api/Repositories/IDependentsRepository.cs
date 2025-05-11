using System.Collections.Generic;
using System.Threading.Tasks;

using EmployeeBenefitCostCalculation.Api.Models;

namespace EmployeeBenefitCostCalculation.Api.Repositories;

public interface IDependentsRepository
{
    /// <summary>
    /// Retrieves all dependents asyncronously.
    /// </summary>
    /// <returns>A collection of all dependents.</returns>
    Task<IEnumerable<Dependent>> GetAllDependentsAsync();

    /// <summary>
    /// Retrieves an dependent by their unique identifier asyncronously.
    /// </summary>
    /// <param name="id">The unique identifier of the dependent.</param>
    /// <returns>The dependent with the specified ID, or null if not found.</returns>
    Task<Dependent?> GetDependentByIdAsync(int id);
}
