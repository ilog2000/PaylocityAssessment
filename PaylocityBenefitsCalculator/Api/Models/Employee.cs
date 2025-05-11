using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeBenefitCostCalculation.Api.Models;

public class Employee : ICloneable
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public decimal Salary { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ICollection<Dependent> Dependents { get; set; } = new List<Dependent>();

    // Make a snapshot of the current state of the Employee object.
    // A deep copy is needed as Dependents are involved in the calculation.
    public object Clone()
    {
        return new Employee
        {
            Id = this.Id,
            FirstName = this.FirstName,
            LastName = this.LastName,
            Salary = this.Salary,
            DateOfBirth = this.DateOfBirth,
            Dependents = this.Dependents.Select(d => (Dependent)d.Clone()).ToList()
        };
    }
}
