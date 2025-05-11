using System.Linq;

using EmployeeBenefitCostCalculation.Api.Dtos.Employee;
using EmployeeBenefitCostCalculation.Api.Models;

namespace EmployeeBenefitCostCalculation.Api.Extensions;

public static class EmployeeMapper
{
    public static GetEmployeeDto ToDto(this Employee employee)
    {
        return new GetEmployeeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Salary = employee.Salary,
            Dependents = employee.Dependents.Select(d => d.ToDto()).ToList()
        };
    }

    public static Employee ToEntity(this GetEmployeeDto dto)
    {
        return new Employee
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Salary = dto.Salary,
            Dependents = dto.Dependents.Select(d => d.ToEntity(dto.Id)).ToList()
        };
    }
}
