using EmployeeBenefitCostCalculation.Api.Models;

namespace EmployeeBenefitCostCalculation.Api.Services;

public interface IEmployeeCalculationRule
{
    Employee Apply(Employee employee);
}
