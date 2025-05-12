using System.Collections.Generic;

using Api.Repositories;
using Api.Services;

using Microsoft.Extensions.DependencyInjection;

namespace Api;

public static class RegistrationExtensions
{
    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        // Register repositories as scoped services to comply with the lifetime of database context 
        services.AddScoped<IEmployeesRepository, EmployeesRepository>();
        services.AddScoped<IDependentsRepository, DependentsRepository>();
        return services;
    }

    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        // Create a list of calculation rules to be applied to the employee
        // TODO: Consider using a configuration service to load the rules
        // TODO: Make a factory to create the rules based on the employee type
        var employeeCalculationRules = new List<IEmployeeCalculationRule>
        {
            new EmployeeBaseRule(),
            new EmployeeHighSalaryRule(),
            new EmployeeDependentBaseRule(),
            new EmployeeDependentAgeRule(),
        };

        services.AddSingleton<ICostCalculationService>(new CostCalculationService(employeeCalculationRules));
        return services;
    }
}
