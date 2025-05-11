using System;
using System.Collections.Generic;

using EmployeeBenefitCostCalculation.Api.Dtos.Dependent;

namespace EmployeeBenefitCostCalculation.Api.Dtos.Employee;

public class GetEmployeeDto
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public decimal Salary { get; set; }
    public decimal MonthlyBenefits { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ICollection<GetDependentDto> Dependents { get; set; } = new List<GetDependentDto>();
}
