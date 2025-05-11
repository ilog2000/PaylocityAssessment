using System;

namespace EmployeeBenefitCostCalculation.Api.Models;

public class Dependent : ICloneable
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Relationship Relationship { get; set; }
    public int EmployeeId { get; set; }

    // Make a snapshot of the current state of the Dependent object.
    public object Clone()
    {
        return new Dependent
        {
            Id = this.Id,
            FirstName = this.FirstName,
            LastName = this.LastName,
            DateOfBirth = this.DateOfBirth,
            Relationship = this.Relationship,
            EmployeeId = this.EmployeeId,
        };
    }
}
