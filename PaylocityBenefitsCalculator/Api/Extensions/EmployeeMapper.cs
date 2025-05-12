using System.Linq;

using Api.Dtos.Employee;
using Api.Models;

namespace Api.Extensions;

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
            DateOfBirth = employee.DateOfBirth,
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
            DateOfBirth = dto.DateOfBirth,
            Dependents = dto.Dependents.Select(d => d.ToEntity(dto.Id)).ToList()
        };
    }
}
