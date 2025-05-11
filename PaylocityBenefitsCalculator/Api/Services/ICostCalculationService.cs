using EmployeeBenefitCostCalculation.Api.Models;

namespace EmployeeBenefitCostCalculation.Api.Services;

public interface ICostCalculationService
{
    Employee CalculateEmployeeCosts(Employee employee);
}
