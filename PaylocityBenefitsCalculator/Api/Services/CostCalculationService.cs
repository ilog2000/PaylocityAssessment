using System.Collections.Generic;

using EmployeeBenefitCostCalculation.Api.Models;

namespace EmployeeBenefitCostCalculation.Api.Services;

public class CostCalculationService : ICostCalculationService
{
    private IEnumerable<IEmployeeCalculationRule> _rules;

    public CostCalculationService(IEnumerable<IEmployeeCalculationRule> rules)
    {
        _rules = rules;
    }

    public Employee CalculateEmployeeCosts(Employee employee)
    {
        foreach (var rule in _rules)
        {
            employee = rule.Apply(employee);
        }

        return employee;
    }
}
