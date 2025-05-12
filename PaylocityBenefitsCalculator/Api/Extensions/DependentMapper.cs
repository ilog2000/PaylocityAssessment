using Api.Dtos.Dependent;
using Api.Models;

namespace Api.Extensions;

public static class DependentMapper
{
    public static GetDependentDto ToDto(this Dependent dependent)
    {
        return new GetDependentDto
        {
            Id = dependent.Id,
            FirstName = dependent.FirstName,
            LastName = dependent.LastName,
            DateOfBirth = dependent.DateOfBirth,
            Relationship = dependent.Relationship
        };
    }

    public static Dependent ToEntity(this GetDependentDto dto, int employeeId)
    {
        return new Dependent
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            DateOfBirth = dto.DateOfBirth,
            Relationship = dto.Relationship,
            EmployeeId = employeeId
        };
    }
}
