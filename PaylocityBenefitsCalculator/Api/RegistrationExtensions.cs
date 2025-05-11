using EmployeeBenefitCostCalculation.Api.Repositories;

using Microsoft.Extensions.DependencyInjection;

namespace EmployeeBenefitCostCalculation.Api;

public static class RegistrationExtensions
{
    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IEmployeesRepository, EmployeesRepository>();
        services.AddScoped<IDependentsRepository, DependentsRepository>();
        return services;
    }
}
