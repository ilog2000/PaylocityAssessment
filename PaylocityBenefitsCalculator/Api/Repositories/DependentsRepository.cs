using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EmployeeBenefitCostCalculation.Api.Models;

namespace EmployeeBenefitCostCalculation.Api.Repositories;

public class DependentsRepository : IDependentsRepository
{
    public Task<IEnumerable<Dependent>> GetAllDependentsAsync()
    {
        // In a real-world scenario, this would be replaced with a database call.
        return Task.FromResult<IEnumerable<Dependent>>(EmployeesStub.Dependents);
    }

    public Task<Dependent?> GetDependentByIdAsync(int id)
    {
        // In a real-world scenario, this would be replaced with a database call.
        var dependent = EmployeesStub.Dependents.FirstOrDefault(e => e.Id == id);
        return Task.FromResult(dependent);
    }
}
