namespace Api;

public class Constants
{
    public const int PaychecksPerYear = 26; // Number of paychecks per year
    public const decimal EmployeeBaseBenefit = 1000.00m; // Base benefit for each employee
    public const decimal SalaryThreshold = 80_000.00m; // Salary threshold for high salary rule
    public const decimal HighSalaryBenefit = 0.02m; // 2% of annual salary
    public const decimal DependentBaseBenefit = 600.00m; // Base benefit for each dependent
    public const int DependentAgeThreshold = 50; // Age threshold for dependent age rule
    public const decimal DependentAgeBenefit = 200.00m; // Benefit for dependents over the age threshold    
}
