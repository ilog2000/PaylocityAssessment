using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EmployeeBenefitCostCalculation.Api.Models;

namespace EmployeeBenefitCostCalculation.Api.Repositories;

public class EmployeesRepository : IEmployeesRepository
{
    public Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        // In a real-world scenario, this would be replaced with a database call.
        return Task.FromResult<IEnumerable<Employee>>(EmployeesStub.Employees);
    }

    public Task<Employee?> GetEmployeeByIdAsync(int id)
    {
        // In a real-world scenario, this would be replaced with a database call.
        var employee = EmployeesStub.Employees.FirstOrDefault(e => e.Id == id);
        return Task.FromResult(employee);
    }
}
